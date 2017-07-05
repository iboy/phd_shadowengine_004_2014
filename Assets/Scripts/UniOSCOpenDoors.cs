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
	/// Uni OSC scale game object.
	/// </summary>
	[AddComponentMenu("UniOSC/UniOSCOpenDoors")]
	public class UniOSCOpenDoors :  UniOSCEventTarget {

		//[HideInInspector]
		//public Transform transformToScale;
		public float scaleFactor = 1;

		public string FirstAddress;
		public string SecondAddress;

		public GameObject targetGameObject;
		//public string targetProperty;
		//public Camera myCamera;

		private Vector3 _scale;
		private float _data;
		private JointSpring spr;

		void Awake(){

		}

		private void _Init(){


			receiveAllAddresses = false;
			_oscAddresses.Clear();
			if (FirstAddress != null) {
				_oscAddresses.Add(FirstAddress); }
			if (SecondAddress != null) {
				_oscAddresses.Add(SecondAddress);
			}
		//	if(transformToScale == null){

				// instead of 'transform to scale'
				// this should be GameObject property / component lookup

				// sets to self
		//		Transform hostTransform = GetComponent<Transform>();
		//		if(hostTransform != null) transformToScale = hostTransform;
		//	}


		}
	
		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}

		public override void OnOSCMessageReceived(UniOSCEventArgs args){

		//	if(transformToScale == null) return;


			if(args.Message.Data.Count <1)return;
			
			if(!( args.Message.Data[0]  is  System.Single))return;
			
			
			
			_data = (float)args.Message.Data[0];
			
			if(String.Equals(args.Address,FirstAddress)){


				if (_data == 0) {
					targetGameObject.rigidbody.hingeJoint.useSpring = true;
					
					spr = targetGameObject.rigidbody.hingeJoint.spring;
					
					spr.targetPosition = 0f;
					
					targetGameObject.rigidbody.hingeJoint.spring = spr;
				}
				
				if (_data < 0) {
					targetGameObject.rigidbody.hingeJoint.useSpring = true;
					spr = targetGameObject.rigidbody.hingeJoint.spring;
					//spr.targetPosition = -72f;
					spr.targetPosition = _data;
					targetGameObject.rigidbody.hingeJoint.spring = spr;
					
				} 


			}

			if(String.Equals(args.Address,SecondAddress)){

				if (_data == 0) {
					targetGameObject.rigidbody.hingeJoint.useSpring = true;
					
					spr = targetGameObject.rigidbody.hingeJoint.spring;
					
					spr.targetPosition = 0f;
					
					targetGameObject.rigidbody.hingeJoint.spring = spr;
				}
				
				if (_data == 1) {
					targetGameObject.rigidbody.hingeJoint.useSpring = true;
					spr = targetGameObject.rigidbody.hingeJoint.spring;
					spr.targetPosition = -72f;
					//spr.targetPosition = _data;
					targetGameObject.rigidbody.hingeJoint.spring = spr;
					
				} 

			}

			//if(args.Message.Data.Count <1)return;

			//_data = (float)args.Message.Data[0];


			//Debug.Log("Received Door Open Message");





		}

	}
}