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
	/// Moves a GameObject in normalized coordinates (ScreenToWorldPoint)
	/// </summary>
	[AddComponentMenu("UniOSC/MoveGameObject")]
	public class UniOSCMoveGameObject :  UniOSCEventTarget {

		[HideInInspector]
		public Transform transformToMove;
		public float nearClipPlaneOffset = 1;
		public enum Mode{Screen,Relative}
		public Mode movementMode;
		//movementModeProp = serializedObject.FindProperty ("movementMode");

		private Vector3 pos;

		void Awake(){

		}


		public override void OnEnable()
		{
			base.OnEnable();

			if(transformToMove == null){
				Transform hostTransform = GetComponent<Transform>();
				if(hostTransform != null) transformToMove = hostTransform;
			}
		}


		public override void OnOSCMessageReceived(UniOSCEventArgs args)
		{
			if(transformToMove == null) return;
			if(args.Message.Data.Count <1)return;

			float x = transformToMove.transform.position.x;
			float y =  transformToMove.transform.position.y;
			float z = transformToMove.transform.position.z;

			switch (movementMode) {

			case Mode.Screen:

				y = Screen.height * (float)args.Message.Data[0];
				
				if(args.Message.Data.Count >= 2){
					x = Screen.width* (float)args.Message.Data[1];
				}
				
				pos = new Vector3(x,y,Camera.main.nearClipPlane+nearClipPlaneOffset);
				transformToMove.transform.position = Camera.main.ScreenToWorldPoint(pos);

				break;

			case Mode.Relative:
				z = 0f;
				y =  (float)args.Message.Data[0];
				if(args.Message.Data.Count >= 2){
					x =  (float)args.Message.Data[1];
				}
				if(args.Message.Data.Count >= 3){
					z =  (float)args.Message.Data[2];
				}

				pos = new Vector3(x,y,z);
				transformToMove.transform.position += pos; 
				break;

			}


		}

	}

}