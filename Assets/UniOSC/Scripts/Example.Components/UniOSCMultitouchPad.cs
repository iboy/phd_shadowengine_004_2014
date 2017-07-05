/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System; 

namespace UniOSC{
	
	/// <summary>
	/// Change the color of the material from the GameObjects.
	/// Option to choose between Material and SharedMaterial
	/// </summary>
	[AddComponentMenu("UniOSC/MultitouchXYPad")]

	public class UniOSCMultitouchPad :  UniOSCEventTarget {
		
		public string FirstTouchAddress;
		public string SecondTouchAddress;
		public string ThirdTouchAddress;
		public string FourthTouchAddress;
		public string FifthTouchAddress;
		public string SixthTouchAddress;

		public string Button001;
		public string Button002;
		public string Button003;
		public string Button004;
		public string Slider001;
		public string Slider002;
		public string Slider003;
		public string Slider004;

		public GameObject FirstControllerObj;
		public Transform FirstController;
		public Transform SecondController;
		public Transform ThirdController;
		public Transform FourthController;
		public Transform FifthController;
		public Transform SixthController;

		public Transform ScalableObject001;
		//public Slider ScalingSliderUI;
		public String rotateObjectKeypress ="r";

		public float OffsetX =0f;
		public float OffsetY =0f;
		public float OffsetZ =0f;
		public float multiplier1 = 1f;
		public float multiplier2 = .8f;
		public float multiplier3 = .6f;
		public float multiplier4 = .4f;
		public float multiplier5 = .3f;
		public float multiplier6 = .2f;

		private Vector3 pos;
		private float value1;
		private float value2;

		public bool doFirstTouchMoveTween = false;
		public bool doSecondTouchMoveTween = false;
		public bool doThirdTouchMoveTween = false;
		public bool doFourthTouchMoveTween = false;
		public bool doFifthTouchMoveTween = false;
		public float firstTouchTweenTime = 1f;
		public float rotationTime = 1f;

		public float maxVariationFactor = .5f;
		public float variationFactor;
		public bool isFacingLeft;


		void Awake(){
			
		}
		
		private void _Init(){
			
			receiveAllAddresses = false;
			_oscAddresses.Clear();
			if (FirstTouchAddress != null) {
				_oscAddresses.Add(FirstTouchAddress); }
			if (SecondTouchAddress != null) {
				_oscAddresses.Add(SecondTouchAddress);
			}
			if (ThirdTouchAddress != null) {
				_oscAddresses.Add(ThirdTouchAddress);
			}
			if (FourthTouchAddress != null) {
				_oscAddresses.Add(FourthTouchAddress);
			}
			if (FifthTouchAddress != null) {
				_oscAddresses.Add(FifthTouchAddress);
			}
			if (SixthTouchAddress != null) {
			_oscAddresses.Add(SixthTouchAddress);
			}

			if (Button001 != null) {
				_oscAddresses.Add(Button001);


			}
			

			if (Slider001 != null) {
				_oscAddresses.Add(Slider001);
				
				
			}
		}
		
		
		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}
		
		
		public override void OnOSCMessageReceived(UniOSCEventArgs args){
			
			if(args.Message.Data.Count <1)return;

			if(!( args.Message.Data[0]  is  System.Single))return;




			
			if(String.Equals(args.Address,FirstTouchAddress)){
				if(FirstController == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z1 = FirstController.transform.transform.position.z;
				Vector3 pos1 = new Vector3(value1*multiplier1+OffsetX, value2*multiplier1+OffsetY, z1);

				Vector3 currentPosition = FirstController.transform.position;

				//doing the tween

				// do a tween from the last pos here

				if (doFirstTouchMoveTween == true) {


					Debug.Log("Doing the firsttouch move tween");
					iTween.MoveTo(FirstController.gameObject, pos1, firstTouchTweenTime);


				} else {


					Debug.Log("Doing follow the finger");
					FirstController.transform.position = pos1;


				}
			}
			if(String.Equals(args.Address,SecondTouchAddress)){
				if(SecondTouchAddress == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z2 = SecondController.transform.position.z;
				Vector3 pos2 = new Vector3(value1*multiplier2+OffsetX, value2*multiplier2+OffsetY, z2);
				SecondController.transform.position = pos2;
			}
			if(String.Equals(args.Address,ThirdTouchAddress)){
				if(ThirdTouchAddress == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z3 = ThirdController.transform.position.z;
				Vector3 pos3 = new Vector3(value1*multiplier3+OffsetX, value2*multiplier3+OffsetY, z3);
				ThirdController.transform.position = pos3;
			}
			if(String.Equals(args.Address,FourthTouchAddress)){
				if(FourthTouchAddress == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z4 = FourthController.transform.position.z;
				Vector3 pos4 = new Vector3(value1*multiplier4+OffsetX, value2*multiplier4+OffsetY, z4);
				FourthController.transform.position = pos4;
			}
			if(String.Equals(args.Address,FifthTouchAddress)){
				if(FifthTouchAddress == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z5 = FifthController.transform.position.z;
				Vector3 pos5 = new Vector3(value1*multiplier5+OffsetX, value2*multiplier5+OffsetY, z5);
				FifthController.transform.position = pos5;


			}
			if(String.Equals(args.Address,SixthTouchAddress)){
				if(SixthTouchAddress == null) return;
				// note flipped values
				value1 = (float)args.Message.Data[1] ;
				value2 = (float)args.Message.Data[0] ;
				float z6 = SixthController.transform.position.z;
				Vector3 pos6 = new Vector3(value1*multiplier6+OffsetX, value2*multiplier6+OffsetY, z6);
				SixthController.transform.position = pos6;

			}
			

			if(String.Equals(args.Address,Button001)){

				value1 = (float)args.Message.Data[0] ;

			//	Debug.Log ("Button Pressed: "+Button001);

				RotatePuppet (FirstControllerObj);

			}

			if(String.Equals(args.Address,Slider001)){
				
				value1 = (float)args.Message.Data[0] ;

			//	Debug.Log ("Slider value: "+value1);
				if (ScalableObject001) {
					ScalePuppet (ScalableObject001, value1,value1,value1 ); }
				//Vector3 scaleVec = new Vector3 (value1, value1, 1);

				
			} 

		}
		public void ScaleFromUI (Slider slider) {
			float value = slider.value;
			float valueX = value;
			Debug.Log (gameObject.name);
			// hard code this flipped object - from now on don't flip objects prior to scripts being attached!
			if (gameObject.name == "MrFryC") {
				valueX = value *-1;
				
			}
			Vector3 scaleVec = new Vector3 (valueX, value, value);

			if (ScalableObject001) {
			ScalableObject001.localScale = scaleVec;
			}


		}
		public void ScalePuppet (Transform scaleTransform, float ScaleX, float ScaleY, float ScaleZ)
		{
			// TODO note exception for this flipped character ... add them here or expose a boolean to indicate 'isFlipped'
			if (scaleTransform.name == "Stephen_Fry_001") {
				ScaleX = ScaleX *-1;

			}
			Vector3 scaleVec = new Vector3 (	ScaleX, ScaleY, ScaleZ);
			scaleTransform.localScale = scaleVec;


		}

		void Update() {
			if (rotateObjectKeypress == null) return;

			if (Input.GetKeyDown(rotateObjectKeypress)) {
				//Debug.Log(rotateObjectKeypress+" pressed.");
				RotatePuppet (FirstControllerObj);

			}



		}
		// experimental to try to itween rotations
		public void IsKinematicFalseZero (GameObject go) {



			string name = go.name;

			//Debug.Log ("Toggling isKinematic false: "+ name);
			if (go.tag == "ControlPoint") {
				go.rigidbody.isKinematic = true;
				//Debug.Log ("This object is a control point.");
				float rotX; float rotZ; 
				rotX = go.transform.eulerAngles.x;
				rotZ = go.transform.eulerAngles.z;
				
				//go.transform.eulerAngles.y = 0;
				go.transform.localEulerAngles = new Vector3 (rotX, 0, rotZ);

				Debug.Log ("Setting to zero CP");
				
			} else {

				if (go.collider != null && go.collider.isTrigger == false)

				{
					go.collider.enabled = false;

				}

			
				go.rigidbody.isKinematic = false;

				// set the y axis rotation to 0

				float rotX; float rotZ; 
				rotX = go.transform.eulerAngles.x;
				rotZ = go.transform.eulerAngles.z;
				//Debug.Log ("Setting to zero others");
				//go.transform.eulerAngles.y = 0;
				go.transform.localEulerAngles =   new Vector3 (rotX, 0, rotZ);




			}

			isFacingLeft = false;
		}

	

		public void IsKinematicFalse180 (GameObject go) {
			
			
			
			string name = go.name;
			
			//Debug.Log ("Toggling isKinematic false: "+ name);
			if (go.tag == "ControlPoint") {
				go.rigidbody.isKinematic = true;
				//Debug.Log ("This object is a control point.");
				float rotX; float rotZ; 
				rotX = go.transform.eulerAngles.x;
				rotZ = go.transform.eulerAngles.z;
				
				//go.transform.eulerAngles.y = 0;


				//go.transform.Rotate(new Vector3 (rotX, 180f, rotZ));
				go.transform.localEulerAngles = new Vector3 (rotX, 180f, rotZ);

				//Debug.Log ("Setting to 180 CP");
				
			} else {
				
				if (go.collider != null && go.collider.isTrigger == false)
					
				{
					go.collider.enabled = false;
					
				}
				
				
				go.rigidbody.isKinematic = false;
				
				// set the y axis rotation to 0
				
				float rotX; float rotZ; 
				rotX = go.transform.eulerAngles.x;
				rotZ = go.transform.eulerAngles.z;
				
				//go.transform.eulerAngles.y = 0;

				//go.transform.Rotate(new Vector3 (rotX, 180f, rotZ));
				//go.transform.Rotate = new Vector3 (rotX, 0, rotZ);
				go.transform.localEulerAngles = new Vector3 (rotX, 180f, rotZ);
				

				//Debug.Log ("Setting to 180 others");
			}
			isFacingLeft = true;
		}


		public void RotatePuppet (GameObject go)
		{

			variationFactor = UnityEngine.Random.Range(0, maxVariationFactor);
			GameObject parent = go.transform.parent.gameObject;

			List<GameObject> children = parent.GetChildren ();
			
			
			int count = children.Count;
			//GameObject[] newSelection2 = new GameObject[count];
			//for(int i = 0; i < count; i++)
			//{
			//	Debug.Log(i);
			//	newSelection2[i] = children.name;
			//}
			
			//GameObject[] newSelection2 = new GameObject[count];
			int i = 0;

			foreach (GameObject str in children) {	
				//newSelection2 [i] = str;
				//Undo.RegisterUndo(str, "Rotate " + str.name);
				
				if (isFacingLeft == true) {


					//Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = true;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.6f;
					//str.rigidbody.collider.enabled = false;
					//if (str.name != "PuppetCamera") {

						//str.transform.eulerAngles = new Vector3 (0, 180f, 0);
					//iTween.RotateTo(str,iTween.Hash("y", 180, iTween.LoopType.none));
					//str.rigidbody.isKinematic = true;
					//iTween.RotateTo(str, new Vector3(0, 180, 0), 1);

					// experimental to try to itween rotations
					iTween.RotateAdd(str, iTween.Hash("y", 180f, "time", rotationTime+variationFactor, "oncomplete", "IsKinematicFalseZero", "oncompletetarget", gameObject, "oncompleteparams",str));

					//}

					//str.rigidbody.collider.enabled = true;
					//Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  false;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount =  0.0f;

					
				} else { 
					//Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = true;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.6f;
					//if (str.name != "PuppetCamera") {
						// would this work with a tween?
						//str.transform.eulerAngles = new Vector3 (0, 0, 0);
						//iTween.RotateTo(str,iTween.Hash("y", 0, iTween.LoopType.none));
					//iTween.RotateTo(str, new Vector3(0, 0, 0), 1);
					//str.rigidbody.isKinematic = true;


					// experimental to try to itween rotations
					iTween.RotateAdd(str, iTween.Hash("y", 180f, "time", rotationTime+variationFactor, "oncomplete", "IsKinematicFalse180", "oncompletetarget", gameObject, "oncompleteparams",str));

					//iTween.RotateTo(str, iTween.Hash("y", 0, "time", 1));

					//}
					//Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  false;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount =  0.0f;

				}
				//Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = false;
				//Debug.Log(str);
				i++;
			}
			//Selection.objects = newSelection2;
			// rotate children
			
			//Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = false;
			//Selection.objects = new UnityEngine.Object[0];
			
		}


		
	}
}