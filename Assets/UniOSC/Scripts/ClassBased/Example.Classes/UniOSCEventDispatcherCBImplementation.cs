/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;

namespace UniOSC{

	/// <summary>
	/// This class is a blueprint for your own implementations of the abstract class UniOSCEventDispatcherCodeBased
	/// Dispatcher forces a OSCConnection to send a OSC Message.
	/// //Don't forget the base callings !!!!
	/// </summary>
	public class UniOSCEventDispatcherCBImplementation : UniOSCEventDispatcherCB {

		#region constructors


		/// <summary>
		/// You have to override the constructors you want to use from the base class <see cref="UniOSC.UniOSCEventDispatcherCodeBased"/> class.
		/// 
		/// </summary>
		public UniOSCEventDispatcherCBImplementation(string _oscOutAddress, string _oscOutIPAddress, int _oscPort): base( _oscOutAddress, _oscOutIPAddress, _oscPort)
		{
		}

		public UniOSCEventDispatcherCBImplementation(string _oscOutAddress, UniOSCConnection _explicitConnection): base(_oscOutAddress, _explicitConnection)
		{
		}
		#endregion


		#region events
		public override void Awake(){
			//Debug.Log("UniOSCEventDispatcherCodeBasedImplementation.Awake");

			//We append our data that we want to send with a message
			//you can also append data from outside the class : instance.AppendData(data)
			//We only can append data types that are supported by the OSC specification:
			//(Int32,Int64,Single,Double,String,Byte[],OscTimeTag,Char,Color,Boolean)
			AppendData(123);//int data at index [0]
			AppendData(123f);// float data at index [1]
			AppendData("MyString");// string data at index [2]
		}


		public override void Enable() 
		{
			//Don't forget this!!!!
			base.Enable();

			//here your custom code
			


		}
		
		public override void Disable()
		{
			//Don't forget this!!!!
			base.Disable();
		}
		#endregion


		/// <summary>
		/// Just a demo method to show how you can change the data of your OSC Message
		/// </summary>
		/// <param name="val">If set to <c>true</c> value.</param>
		public void SetDataAtIndex0(bool val){
			_OSCeArg.Message.UpdateDataAt(0,System.Convert.ToInt32(val));
			_OSCeArg.Message.UpdateDataAt(1,System.Convert.ToSingle(!val));
		}

	

	}
}
