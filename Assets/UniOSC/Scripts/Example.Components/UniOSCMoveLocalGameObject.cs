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
	[AddComponentMenu("UniOSC/MoveLocalGameObject")]
	public class UniOSCMoveLocalGameObject :  UniOSCEventTarget {

		[HideInInspector]
		public Transform transformToMove;
		public float nearClipPlaneOffset = 1;
		public float xOffset = 0;
		public float yOffset = 0;
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

			float x = transformToMove.transform.position.x+xOffset;
			float y = transformToMove.transform.position.y+yOffset;
			float z = transformToMove.transform.position.z;

			//Debug.Log("X = "+x+"; "+"Y = "+y+"; "+"Z = "+z+";");
			//y = Screen.height * (float)args.Message.Data[0];
			y = (float)args.Message.Data[0]+yOffset;

			if(args.Message.Data.Count == 2){
				//x = Screen.width* (float)args.Message.Data[1];
				x = (float)args.Message.Data[1]+xOffset;
			}

			//pos = new Vector3(x,y,0);
			pos = new Vector3(x,y,z);
			//transformToMove.transform.localPosition = Camera.main.ScreenToWorldPoint(pos);
			transformToMove.transform.position = pos;
		}

	}

}