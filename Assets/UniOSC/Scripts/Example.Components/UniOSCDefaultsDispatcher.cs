/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;


namespace UniOSC{

	/// <summary>
	/// This class is a blueprint for your own implementations of the abstract class UniOSCEventDispatcher
	/// Dispatcher forces a OSCConnection to send a OSC Message.
	/// //Don't forget the base callings !!!!
	/// </summary>
	[AddComponentMenu("UniOSC/Set UI Defaults")]
	[ExecuteInEditMode]
	public class UniOSCDefaultsDispatcher: UniOSCEventDispatcher {

		// why aren't these in the interface
		public int dynamicIntValue= 1000;
		public float dynamicFloatValue= 1000f;
		public string dynamicStringValue = "Noel";

		public override void Awake ()
		{
			base.Awake ();
			//here your custom code
			AppendData("test");
			//MySendOSCMessageTriggerMethod();

		}

	
		public override void OnEnable ()
		{
			//Don't forget this!!!!
			//In the base class we setup our OSC message that is send later
			//after this we can append our data to the message
			base.OnEnable ();


			//here your custom code

			//We append our data that we want to send with a message
			//later in the your "MySendOSCMessageTrigerMethod" you change this data with :
			//_OSCeArg.Message.UpdateDataAt(index,yourValue); 
			//We only can append data types that are supported by the OSC specification:
			//(Int32,Int64,Single,Double,String,Byte[],OscTimeTag,Char,Color,Boolean)

			//AppendData(123);//int data at index [0]
			//AppendData(123f);// float data at index [1]
			//AppendData("Tab1");// string data at index [2]
			//.......

			MySendOSCMessageTriggerMethod();
		}


		void OnGUI() {


			if (GUI.Button(new Rect(10, 70, 120, 120), "Update Controller UI")) {
				Debug.Log("Clicked the button with text");
			MySendOSCMessageTriggerMethod();

		}


		}
		public override void OnDisable ()
		{
			//Don't forget this!!!!
			base.OnDisable ();
			//here your custom code
			//MySendOSCMessageTriggerMethod();
		}


		/// <summary>
		/// Just a dummy method that shows how you trigger the OSC sending and how you could change the data of the OSC Message 
		/// </summary>
		public void MySendOSCMessageTriggerMethod(){
			//Here we update the data with a new value

			//_OSCeArg.Message.UpdateDataAt(0,dynamicStringValue);
			//_OSCeArg.Message.UpdateDataAt(1,dynamicFloatValue);
			//_OSCeArg.Message.UpdateDataAt(2,dynamicStringValue);

			//Here we trigger the sending
			//_SendOSCMessage(_OSCeArg);
		}


	}
}