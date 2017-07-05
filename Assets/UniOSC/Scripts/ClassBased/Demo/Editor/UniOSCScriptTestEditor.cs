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
	[Serializable]
	public class UniOSCScriptTestEditor : EditorWindow {
	
		#region private
		private  UniOSCEventTargetCBImplementation oscTarget1;
		private  UniOSCEventTargetCBImplementation oscTarget2;
		private  UniOSCEventTargetCBImplementation oscTarget3;
		private  UniOSCEventTargetCBImplementation oscTarget4;
		private  UniOSCEventTargetCBImplementation oscTarget5;

		private UniOSCEventDispatcherCBImplementation oscSender1;

		private int OSCPort = 8000;
		private UniOSCConnection OSCConnection;
		private int OSCConnectionID = 0;
		private string OSCAddress = "/1/push7";
		private string OSCOutAddress = "/2/push7";

		private string oscTarget1Msg;
		#endregion

		public static UniOSCScriptTestEditor Instance { get; private set; }

		static EditorWindow _windowSelf;

		public static bool IsOpen {
			get { return Instance != null; }
		}

		[MenuItem("Window/UniOSC/Test/ScriptTestEditor")]
		static void _Init(){
			_windowSelf = EditorWindow.GetWindow(typeof(UniOSCScriptTestEditor));
			_windowSelf.title ="UniOSC Test Editor";
			_windowSelf.minSize = new Vector2(256f,256f);
			_windowSelf.autoRepaintOnSceneChange = true;
		}

		#region Enable
		public void OnEnable() {
		//	Debug.Log("OnEnable");

			// We need to monitor the playmodeStateChanged event to update the references to OSCConnections (only necessary when we use the explicitConnection feature)
			//and force a new connection setup through disable/enable on our OSCEventTargets otherwise we have to re-open our Editor 
			EditorApplication.playmodeStateChanged += _HandleOnPlayModeChanged;

			//Here we show the different possibilities to create a OSCEventTarget from code:

			//When we only specify a port we listen to all OSCmessages on that port (We assume that there is a OSCConnection with that listening port in our scene)
			oscTarget1 = new UniOSCEventTargetCBImplementation(OSCPort);
			oscTarget1.OSCMessageReceived+=OnOSCMessageReceived1;
			oscTarget1.Enable();

			//When we use a OSCConnection in the constructor of a OSCEventTarget instance we need to also store the InstanceID to be able to re-reference it on playmodeStateChanges!
			OSCConnection = FindObjectOfType<UniOSCConnection>() as UniOSCConnection;
			if(OSCConnection != null) OSCConnectionID =OSCConnection.GetInstanceID();

			//This implies that we use the explicitConnection mode. (With responding to all OSCmessages)
			oscTarget2 = new UniOSCEventTargetCBImplementation(OSCConnection);
			oscTarget2.OSCMessageReceived+=OnOSCMessageReceived2;
			oscTarget2.Enable();

			//We listen to a special OSCAddress regardless of the port.
			oscTarget3 = new UniOSCEventTargetCBImplementation(OSCAddress);
			oscTarget3.OSCMessageReceived+=OnOSCMessageReceived3;
			oscTarget3.Enable();

			//The standard : respond to a given OSCAddress on a given port
			oscTarget4 = new UniOSCEventTargetCBImplementation(OSCAddress, OSCPort);
			oscTarget4.OSCMessageReceived+=OnOSCMessageReceived4;
			oscTarget4.Enable();

			//This version has the advantage that we are not bound to a special port. If the connection changes the port we still respond to the OSCMessage
			oscTarget5 = new UniOSCEventTargetCBImplementation(OSCAddress,OSCConnection);
			oscTarget5.OSCMessageReceived+=OnOSCMessageReceived5;
			oscTarget5.Enable();

			oscSender1 = new UniOSCEventDispatcherCBImplementation(OSCOutAddress,OSCConnection);
			oscSender1.AppendData("TestData");
			oscSender1.AppendData(12345);
			oscSender1.Enable();

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
			
			//When we change the playmode we have to trigger a new Connection setup on our oscTargets, otherwise we loose our event binding!

			UniOSCConnection actualCon = null;
			if(OSCConnectionID >= 0) {
				actualCon = EditorUtility.InstanceIDToObject(OSCConnectionID) as UniOSCConnection;
			}


			if(oscTarget1.isEnabled){
				oscTarget1.Disable();
				oscTarget1.Enable();
			}

			//If we use a explicitConnection we need to update the reference to the OSCConection:
			if(oscTarget2.isEnabled){
				oscTarget2.Disable();
				oscTarget2.SetExplicitConnection(actualCon);
				oscTarget2.Enable();
			}

			if(oscTarget3.isEnabled){
				oscTarget3.Disable();
				oscTarget3.Enable();
			}

			if(oscTarget4.isEnabled){
				oscTarget4.Disable();
				oscTarget4.Enable();
			}

			if(oscTarget5.isEnabled){
				oscTarget5.Disable();
				oscTarget5.SetExplicitConnection(actualCon);
				oscTarget5.Enable();
			}

			if(oscSender1.isEnabled){
				oscSender1.Disable();
				oscSender1.SetExplicitConnection(actualCon);
				oscSender1.Enable();
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
			if(GUILayout.Button(new GUIContent("Send Data","Send Data"),GUILayout.MinHeight(30))){
				//Debug.Log("OnOSCMessageSend1:");
				oscSender1.SendOSCMessage();
			}

			GUILayout.Space(10);
			GUILayout.Label("oscTarget1 OSC IN Message:");
			GUILayout.Label(oscTarget1Msg);

		}

		#region Disable
		public void OnDisable() 
		{
			//Debug.Log("OnDisable");

			EditorApplication.playmodeStateChanged -= _HandleOnPlayModeChanged;

			oscTarget1.Dispose();
			oscTarget1 = null;
			
			oscTarget2.Dispose();
			oscTarget2 = null;
			
			oscTarget3.Dispose();
			oscTarget3 = null;
			
			oscTarget4.Dispose();
			oscTarget4 = null;
			
			oscTarget5.Dispose();
			oscTarget5 = null;

			oscSender1.Dispose();
			oscSender1 = null;
		}
		#endregion

		#region callbacks
		//our custom callback methods to handle the OSC data in our editor
		private void OnOSCMessageReceived1(object sender, UniOSCEventArgs args){
			Debug.Log("OnOSCMessageReceived1:"+args.Message.Address);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(args.Message.Address);
			foreach(var d in args.Message.Data){
				sb.AppendLine(d.ToString());
			}

			oscTarget1Msg = sb.ToString();
		}
		private void OnOSCMessageReceived2(object sender, UniOSCEventArgs args){
			Debug.Log("OnOSCMessageReceived2:"+args.Message.Address);
		}
		private void OnOSCMessageReceived3(object sender, UniOSCEventArgs args){
			Debug.Log("OnOSCMessageReceived3:"+args.Message.Address);
		}
		private void OnOSCMessageReceived4(object sender, UniOSCEventArgs args){
			Debug.Log("OnOSCMessageReceived4:"+args.Message.Address);
		}
		private void OnOSCMessageReceived5(object sender, UniOSCEventArgs args){
			Debug.Log("OnOSCMessageReceived5:"+args.Message.Address);
		}
		#endregion

	}
}
