/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Text;
using OSCsharp.Data;

namespace UniOSC{

	/// <summary>
	/// GUI class that mimics the UniOSC editor interface for runtime use
	/// You can start/stop the OSCConnections and trace OSC data messages
	/// </summary>
	[AddComponentMenu("UniOSC/OSCGUI")]
	[ExecuteInEditMode]
	public class UniOSCGUI : MonoBehaviour {
		
		#region private
		private string _IPAddress;
		private bool _showGUI= true;
		private GUIStyle gs_textArea ;
		private Vector2 traceScrollpos = new Vector2();
		private string msgMode;
		private OscMessage _oscMessage;
		private string _oscTraceStr="";
		private StringBuilder _osctraceStrb = new StringBuilder();
		private Texture2D tex_logo;
		#endregion

		#region public
		public bool ShowInEditMode;
		public bool traceMessages;
		#endregion

		#region Start
		void Awake(){
			DontDestroyOnLoad(gameObject);
		}

		void Start () {

		}

		void OnEnable(){
			_IPAddress = UniOSCUtils.GetLocalIPAddress();
			foreach(var con in UniOSCConnection.Instances){
				con.OSCMessageReceived+=OnOSCMessageReceived;
				con.OSCMessageSend+=OnOSCMessageSended;
			}
			tex_logo = Resources.Load(UniOSCUtils.LOGO32_NAME,typeof(Texture2D)) as Texture2D;
		}

		#endregion Start

		void OnDisable(){
			foreach(var con in UniOSCConnection.Instances){
				con.OSCMessageReceived-=OnOSCMessageReceived;
				con.OSCMessageSend-=OnOSCMessageSended;
			}
		}
	
		void Update () {
		
		}

		#region GUI

		void OnGUI(){
			if(!Application.isPlaying){
				if(!ShowInEditMode)return;
			}

			GUIScaler.Begin();
			GUILayout.BeginVertical(GUILayout.Width(Screen.width/GUIScaler.GuiScale.x),GUILayout.Height(Screen.height/(GUIScaler.GuiScale.y)));//
			GUILayout.Space(10f);

			#region IPAddress
				GUILayout.BeginHorizontal();
					GUILayout.Space(10f);
					UniOSCUtils.DrawTexture(tex_logo);
					GUILayout.FlexibleSpace();
					GUILayout.Label(_IPAddress,GUILayout.Height(30f));
					GUILayout.FlexibleSpace();
					_showGUI = GUILayout.Toggle(_showGUI,new GUIContent(_showGUI? "Hide GUI":"Show GUI"),GUI.skin.button,GUILayout.Height(30),GUILayout.Width(130));
					GUILayout.Space(10f);
				GUILayout.EndHorizontal();
			#endregion IPAddress

			if(!_showGUI){
				GUILayout.EndVertical();
					GUIScaler.End();
				return;
			}

			GUILayout.Space(10f);

			GUILayout.BeginHorizontal();

			GUILayout.FlexibleSpace();

			#region OSCConnections
			GUILayout.BeginVertical();

				foreach(var con in UniOSCConnection.Instances){
					if(con.gameObject.activeInHierarchy && con.enabled){
						con.RenderGUI();
						GUILayout.Space(5f);
					}//if
				}//for

			GUILayout.EndVertical();
			#endregion OSCConnections

			GUILayout.FlexibleSpace();

			#region trace
			if(gs_textArea == null){
			gs_textArea = new GUIStyle(GUI.skin.textArea);
			gs_textArea.fontSize=10;
			gs_textArea.normal.textColor =  Color.yellow;
			}

			GUILayout.BeginVertical(GUILayout.Width(200f));

				traceScrollpos = GUILayout.BeginScrollView(traceScrollpos,  GUILayout.Height (((Screen.height/GUIScaler.GuiScale.y)*0.75f)-40f), GUILayout.ExpandHeight (false));
					GUILayout.TextArea(_oscTraceStr,gs_textArea,GUILayout.ExpandHeight(true));
				GUILayout.EndScrollView();
				
				if (GUILayout.Button ("Clear Trace",GUILayout.Height(30))){
					_oscTraceStr = "";
					_osctraceStrb = new StringBuilder();
				}

			GUILayout.EndVertical();
			#endregion trace
				GUILayout.Space(10f);
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();

			GUIScaler.End();
		}

		#endregion GUI

		#region Message

		private void OnOSCMessageSended(object sender, UniOSCEventArgs args){
			if(traceMessages)_TraceOSCMessage( sender,args,false);
		}

		private void OnOSCMessageReceived(object sender, UniOSCEventArgs args){
				if(!_showGUI)return;
			if(traceMessages)_TraceOSCMessage(sender,args,true);
		}

		private void _TraceOSCMessage(object sender,UniOSCEventArgs args,bool oscIn){
		
			msgMode = oscIn ? "IN" : "OUT";
			_oscMessage = args.Message;
			_osctraceStrb.AppendLine("----Message "+msgMode+"-----");
			if(oscIn){
				_osctraceStrb.AppendLine("Port:" +((UniOSCConnection)sender).oscPort);
			}else{
				_osctraceStrb.AppendLine("Destination IP:" +((UniOSCConnection)sender).oscOutIPAddress);
				_osctraceStrb.AppendLine("Port:" +((UniOSCConnection)sender).oscOutPort);
			}
			
			_osctraceStrb.AppendLine("Address: "+_oscMessage.Address.ToString());
			
			if (_oscMessage.Data.Count >0) {
				for (int i =0;i< _oscMessage.Data.Count;i++){
					_osctraceStrb.AppendLine("Data: "+_oscMessage.Data[i].ToString());
				}
			}
			
			_oscTraceStr = _osctraceStrb.ToString();
			//autoscroll to bottom
			traceScrollpos = new Vector2(0f,Mathf.Infinity);
		}
		#endregion Message

	}
}