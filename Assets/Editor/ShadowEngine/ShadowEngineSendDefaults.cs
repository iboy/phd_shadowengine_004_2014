/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace UniOSC{
	
	/// <summary>
	/// Editor for the administration of OSCconnections, mapping files.
	/// You can also trace the OSC data flow .
	/// </summary>
	/// 
	/// 
	/// 
	
	//public string ianIsCool = "ian is cool";
	
	[Serializable]
	public class ShadowEngineSendDefaults : EditorWindow {
		//bool groupEnabled;
		//bool myBool = true;
		//float myFloat = 1.23f;
		#region private

		public string pageLabel1;
		public string pageLabel2;
		public string pageLabel3;
		public string pageLabel4;
		public string pageLabel5;
		
		private UniOSCEventDispatcherCBImplementation oscSender1;
		private UniOSCEventDispatcherCBImplementation oscSender2;
		private UniOSCEventDispatcherCBImplementation oscSender3;
		private UniOSCEventDispatcherCBImplementation oscSender4;
		private UniOSCEventDispatcherCBImplementation oscSender5;
		private UniOSCEventDispatcherCBImplementation oscSender6;


		private List<UniOSCConnection> _myOSCConnections = new List<UniOSCConnection>() ;
		//private int OSCPort = 9000;
		private UniOSCConnection OSCConnection;
		private int OSCConnectionID = 0;

		private string OSCOutAddress1 = "/pageLabel001";
		private string OSCOutAddress2 = "/pageLabel002";
		private string OSCOutAddress3 = "/pageLabel003";
		private string OSCOutAddress4 = "/pageLabel004";
		private string OSCOutAddress5 = "/pageLabel005";
		
		private string oscTarget1Msg;
		#endregion
		
		public static SetDefaultsEditor Instance { get; private set; }
		
		static EditorWindow _windowSelf;
		
		public static bool IsOpen {
			get { return Instance != null; }
		}
		
		[MenuItem("ShadowEngine/Send Defaults")]
		static void _Init(){
			_windowSelf = EditorWindow.GetWindow(typeof(ShadowEngineSendDefaults));
			_windowSelf.title ="Send Controller Defaults";
			_windowSelf.minSize = new Vector2(256f,256f);
			_windowSelf.autoRepaintOnSceneChange = true;
		}
		
		#region Enable
		public void OnEnable() {
			//	Debug.Log("OnEnable");
			
			// We need to monitor the playmodeStateChanged event to update the references to OSCConnections (only necessary when we use the explicitConnection feature)
			//and force a new connection setup through disable/enable on our OSCEventTargets otherwise we have to re-open our Editor 
			EditorApplication.playmodeStateChanged += _HandleOnPlayModeChanged;
			
		
			//When we use a OSCConnection in the constructor of a OSCEventTarget instance we need to also store the InstanceID to be able to re-reference it on playmodeStateChanges!



			OSCConnection = FindObjectOfType<UniOSCConnection>() as UniOSCConnection;

			// list of all connections
			//_myOSCConnections



			if(OSCConnection != null) { OSCConnectionID =OSCConnection.GetInstanceID();
			//Debug.Log(OSCConnection.GetInstanceID());

				//int numberOfConnections = FindObjectsOfTypeAll(typeof(UniOSCConnection)).Length;


				//L[] numberOfConnections = FindObjectsOfType(typeof(UniOSCConnection)) as UniOSCConnection[];

//				Debug.Log("IP: "+OSCConnection.oscOutIPAddress+" Port:"+OSCConnection.oscOutPort+" Instance ID: "+OSCConnection.GetInstanceID);
				Debug.Log("OSC Connections:" + _myOSCConnections.Count);

			//public UniOSCEventDispatcherCBImplementation(string _oscOutAddress, string _oscOutIPAddress, int _oscPort): base( _oscOutAddress, _oscOutIPAddress, _oscPort)
			//oscSender1 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress1,"10.0.1.10", 9000);
			oscSender1 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress1,OSCConnection);
			oscSender1.AppendData(pageLabel1);
			//oscSender1.AppendData(pageLabel1);
			//oscSender1.AppendData(pageLabel1);
			oscSender1.Enable();

			
				//oscSender2 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress2,"10.0.1.10", 9000);
				oscSender2 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress2,OSCConnection);
			oscSender2.AppendData(pageLabel2);
			//oscSender1.AppendData("b");
			oscSender2.Enable();

			
			//	oscSender3 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress3,"10.0.1.10", 9000);
				oscSender3 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress3,OSCConnection);
			oscSender3.AppendData(pageLabel3);
			//oscSender1.AppendData("b");
			oscSender3.Enable();

			
				//oscSender4 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress4,"10.0.1.10", 9000);
				oscSender4 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress4,OSCConnection);
			oscSender4.AppendData(pageLabel4);
			//oscSender1.AppendData("b");
			oscSender4.Enable();

			
				//oscSender5 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress5,"10.0.1.10", 9000);
				oscSender5 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress5,OSCConnection);
			oscSender5.AppendData(pageLabel5);
			//oscSender1.AppendData("b");
			oscSender5.Enable();
			}
		}
		#endregion
		
		#region PlayModeChanged
		private void _HandleOnPlayModeChanged()
		{
			// This method is run whenever the playmode state is changed.
			if(Application.isPlaying){
				//Debug.Log("PLAY");
			}else{
				//Debug.Log("STOP");
			}
			
			//When we change the playmode we have to trigger a new Connection setup on our oscTargets, otherwise we lose our event binding!
			
			UniOSCConnection actualCon = null;
			if(OSCConnectionID >= 0) {
				actualCon = EditorUtility.InstanceIDToObject(OSCConnectionID) as UniOSCConnection;
			}
			//Debug.Log("OSC Connections (playmodechanged):" + _myOSCConnections.Count);
			//Debug.Log("OSCConnectionID="+OSCConnectionID);

			
			if(oscSender1.isEnabled){
				oscSender1.Disable();
				oscSender1.SetExplicitConnection(actualCon);
				oscSender1.Enable();
			}

			if(oscSender2.isEnabled){
				oscSender2.Disable();
				oscSender2.SetExplicitConnection(actualCon);
				oscSender2.Enable();
			}

			if(oscSender3.isEnabled){
				oscSender3.Disable();
				oscSender3.SetExplicitConnection(actualCon);
				oscSender3.Enable();
			}

			if(oscSender4.isEnabled){
				oscSender4.Disable();
				oscSender4.SetExplicitConnection(actualCon);
				oscSender4.Enable();
			}
			
			/*
			if (! EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
			{
				
				Debug.Log("PLAY");
			}

			if (EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
			{
					Debug.Log("STOP");
			}
			*/
			
			
		}
		#endregion
		
		// called at 10 frames per second to give the editor a chance to update.
		void OnInspectorUpdate(){
			//with unity 4 we loose Tooltips with this :-( 
			Repaint();
		}
		void OnGUI()
		{

			GUILayout.Label ("OSC GUI Labels", EditorStyles.boldLabel);
			pageLabel1 = EditorGUILayout.TextField ("Page 1", pageLabel1);
			pageLabel2 = EditorGUILayout.TextField ("Page 2", pageLabel2);
			pageLabel3 = EditorGUILayout.TextField ("Page 3", pageLabel3);
			pageLabel4 = EditorGUILayout.TextField ("Page 4", pageLabel4);
			pageLabel5 = EditorGUILayout.TextField ("Page 5", pageLabel5);
			
			//groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
			//myBool = EditorGUILayout.Toggle ("Toggle", myBool);
			//myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
			//EditorGUILayout.EndToggleGroup ();

			if(GUILayout.Button(new GUIContent("Send Data", "Send Data"),GUILayout.MinHeight(30))){
				Debug.Log("OnOSCMessageSend All");
				oscSender1.ClearData();
				oscSender1.AppendData(pageLabel1);
				oscSender1.Enable();
				oscSender1.SendOSCMessage();

				oscSender2.ClearData();
				oscSender2.AppendData(pageLabel2);
				oscSender2.Enable();
				oscSender2.SendOSCMessage();

				oscSender3.ClearData();
				oscSender3.AppendData(pageLabel3);
				oscSender3.Enable();
				oscSender3.SendOSCMessage();

				oscSender4.ClearData();
				oscSender4.AppendData(pageLabel4);
				oscSender4.Enable();
				oscSender4.SendOSCMessage();

				oscSender5.ClearData();
				oscSender5.AppendData(pageLabel5);
				oscSender5.Enable();
				oscSender5.SendOSCMessage();
			}
			
			//GUILayout.Space(10);
			//GUILayout.Label("oscTarget1 OSC IN Message:");
			//GUILayout.Label(oscTarget1Msg);
			
		}



		#region Disable
		public void OnDisable() 
		{
			//Debug.Log("OnDisable");
			
			EditorApplication.playmodeStateChanged -= _HandleOnPlayModeChanged;

			
			oscSender1.Dispose();
			oscSender1 = null;

			oscSender2.Dispose();
			oscSender2 = null;
			
			oscSender3.Dispose();
			oscSender3 = null;
			
			oscSender4.Dispose();
			oscSender4 = null;
			
			oscSender5.Dispose();
			oscSender5 = null;
		}
		#endregion
		
		#region callbacks
		//our custom callback methods to handle the OSC data in our editor

		#endregion
		
	}
}
