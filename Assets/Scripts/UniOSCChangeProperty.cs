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
	[AddComponentMenu("UniOSC/ChangeProperty")]
	public class UniOSCChangeProperty :  UniOSCEventTarget {

		[HideInInspector]
		//public Transform transformToScale;
		public float scaleFactor = 1;

		public GameObject targetGameObject;
		public string targetProperty;
		public Camera myCamera;

		private Vector3 _scale;
		private float _data;


		void Awake(){

		}

		private void _Init(){
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

			_data = (float)args.Message.Data[0];

			if (_data == 0.2f) {
				// the idea here is to help selection in the scene view by hiding the 
				// large square texture of the iris - 
				// TODO check if there is a way of making GOs unselectable in the editor.

				//targetGameObject.SetActive(false);
				targetGameObject.renderer.enabled = false;

			} else {

				//targetGameObject.SetActive(true);
				targetGameObject.renderer.enabled = true;
				targetGameObject.renderer.sharedMaterial.SetFloat( "_Radius", _data );
			
			
			}

			//if (targetGameObject.renderer.sharedMaterial.GetFloat("_Radius")
			//     == 0.2f) {
			//	targetGameObject.SetActive(false);
			//
			//} else { 
			//
			//	targetGameObject.SetActive(true);
			//
			//}
			//_data*= scaleFactor;
			//_scale.Set(_data,_data,_data);

			//transformToScale.localScale = _scale;

		}

	}
}