/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace UniOSC{

	/// <summary>
	/// With this class you can toggle most of the Unity Components on/off
	/// The data of the OSC message should be only 0(off) or 1(on)
	/// </summary>
	[AddComponentMenu("UniOSC/Toggle")]
	public class UniOSCToggle :  UniOSCEventTarget {
	
		[HideInInspector]
		public Component componentToToggle;
		[HideInInspector]
		public bool toggleState;

		private Type _compType;


		void Awake(){
		}


		private void _Init(){
			if(componentToToggle == null){
				componentToToggle = gameObject.transform;
			}
			if(componentToToggle != null) _compType =componentToToggle.GetType();
			UpdateComponentState();
		}

		/// <summary>
		/// Updates the state of the component.(enabled)
		/// </summary>
		public void UpdateComponentState(){
			
			if(_compType == null) return;
			
			if(_compType.IsSubclassOf( typeof(Behaviour)) ){
				((Behaviour)componentToToggle).enabled = toggleState;
				return;
			}
			
			if(_compType.IsSubclassOf( typeof(Renderer)) ){
				((Renderer)componentToToggle).enabled = toggleState;
				return;
			}
			
			if(_compType.IsSubclassOf( typeof(Collider)) ){
				((Collider)componentToToggle).enabled = toggleState;
				return;
			}
			
			if(_compType.IsSubclassOf( typeof(Cloth)) ){
				((Cloth)componentToToggle).enabled = toggleState;
				return;
			}
			
		}



		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}
	

		public override void OnOSCMessageReceived(UniOSCEventArgs args){

			if(args.Message.Data.Count <1)return;
			if(!( args.Message.Data[0]  is  System.Single))return;

			toggleState = Convert.ToBoolean(args.Message.Data[0]) ;
			UpdateComponentState();
		}

	}

}