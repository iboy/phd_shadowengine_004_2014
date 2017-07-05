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
	/// Change the color of the material from the GameObjects.
	/// Option to choose between Material and SharedMaterial
	/// </summary>
	[AddComponentMenu("UniOSC/CinematicContoller")]
	//[RequireComponent(typeof(MeshRenderer))]
	public class UniOSCCinematicController :  UniOSCEventTarget {

		// fader
		public Texture2D cameraTexture;
		public float fadeOutDuration = 2.0f;
		public float fadeInDuration = 2.0f;
		public GameObject FaderFXPlane;

		// iris
		public GameObject iris;
		public float irisOffsetX = 0f;
		public float irisOffsetY = 0f;
		private float value;
		private float value2;

		//colorpicker
		public ColorPicker myColorPicker; //_ColorPicker (ColorPicker)
		public Texture2D colorPickerTex; //colorpicker_texture

		// camera moves
		public bool interactiveCameraMove = true;
		public float CameraOrthoResetTime = 1f;
		public float CameraPositionResetTime =1f;
		public float CameraMoveTime =1f;

	

		 

		//public string R_Address;
		//public string G_Address;
		//public string B_Address;

		//public bool sharedMaterial;

		//private Vector3 pos;
		//private Material _mat;


	
		void Awake(){


		}

		private void _Init(){
			//iTween.CameraFadeAdd(cameraTexture,200);
			receiveAllAddresses = false;
			_oscAddresses.Clear();
			_oscAddresses.Add("/3/AutoFade");
			_oscAddresses.Add("/3/ManualFadeSlider");
			_oscAddresses.Add("/3/CameraTypeToggle/1/1");
			_oscAddresses.Add("/3/CameraZoomOrtho");
			_oscAddresses.Add("/3/CameraZoomPerspective");
			_oscAddresses.Add("/3/CamOrthoDefaultSize");
			_oscAddresses.Add("/3/CamPerspectiveDefaultFOV");
			_oscAddresses.Add("/3/DOFFocalDistance");
			_oscAddresses.Add("/3/DOFToggle");
			_oscAddresses.Add("/3/FXBlur");
			_oscAddresses.Add("/3/FXGreyScaleToggle");
			_oscAddresses.Add("/3/FXMonochromeToggle");
			_oscAddresses.Add("/3/FXMotionBlur");
			_oscAddresses.Add("/3/FXNoiseToggle");
			_oscAddresses.Add("/3/FXSepiaToggle");
			_oscAddresses.Add("/3/FXSunShaftsIntensity");
			_oscAddresses.Add("/3/FXShaftColorPickerXY");
			_oscAddresses.Add("/3/FXSunShaftsToggle");
			_oscAddresses.Add("/3/FXVignetteBlur");
			_oscAddresses.Add("/3/FXVignetteChromatic");
			_oscAddresses.Add("/3/FXVignetteSetDefaults");
			_oscAddresses.Add("/3/FXVignetteSize");
			_oscAddresses.Add("/3/IrisInCentroid");
			_oscAddresses.Add("/3/IrisOutCentroid");
			_oscAddresses.Add("/3/IrisTransitionSpeed");
			_oscAddresses.Add("/3/IrisLocationXYPad");

			_oscAddresses.Add("/3/ManualFadeSlider");
			_oscAddresses.Add("/3/FXInvertColors");

			//_oscAddresses.Add("/3/CameraZoomOrtho");
			_oscAddresses.Add("/CameraMove");
			_oscAddresses.Add("/CameraMove/z");

			_oscAddresses.Add("/ToggleCameraFollowOrPointClick");
			
			//if(sharedMaterial ){
			//	_mat = gameObject.renderer.sharedMaterial;
			//}else{
			//	if(Application.isPlaying){
			//		_mat = gameObject.renderer.material;
			//	}else{
			//		_mat = null;
			//	}
			//}
		}


		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}

		void UpdateCameraOrtho( float size ) {
			// Will be called each frame by iTween
			// This is where you apply the size
			Camera.main.orthographicSize = size;
		}

		void UpdateCameraX( float size ) {
			// Will be called each frame by iTween
			// This is where you apply the size
			Vector3 camPosX = Camera.main.transform.position;
			camPosX.x = size;
			Camera.main.transform.position = camPosX;
		}

		void UpdateCameraY( float size ) {
			// Will be called each frame by iTween
			// This is where you apply the size
			Vector3 camPosY = Camera.main.transform.position;
			camPosY.y = size;
			Camera.main.transform.position = camPosY;
		}
	
		public override void OnOSCMessageReceived(UniOSCEventArgs args){
		
			if(args.Message.Data.Count <1)return;


			if(!( args.Message.Data[0]  is  System.Single))return;
			 value = (float)args.Message.Data[0] ;
			if (args.Message.Data.Count ==2) {

				 value2 = (float)args.Message.Data[1] ;

			}


			if(String.Equals(args.Address,"/CameraMove")){

				float z1 = Camera.main.transform.position.z;
				Vector3 pos1 = new Vector3(value2, value, z1);
			
				if (interactiveCameraMove == true) {
			
				 
					Camera.main.transform.position = pos1;

				} else {

					iTween.MoveTo(Camera.main.gameObject, pos1,CameraMoveTime);


				}




			}

			if(String.Equals(args.Address,"/ToggleCameraFollowOrPointClick")){

				interactiveCameraMove = !interactiveCameraMove;

			}

			if(String.Equals(args.Address,"/3/AutoFade")){

				// do the right thing
				if (value == 1) {
					Debug.Log("Autofade In");
					iTween.CameraFadeTo(1,fadeInDuration);
				
				}
				if (value == 0) {
					Debug.Log("Autofade Out");
					iTween.CameraFadeTo(0,fadeOutDuration);
				}


			}


			if(String.Equals(args.Address,"/3/ManualFadeSlider")){
				
				// do the right thing
				//FaderFXPlane.renderer.material
				FaderFXPlane.renderer.material.color = new Color(0,0,0,value);

				
				
			}


			// toggle camera type
			if(String.Equals(args.Address,"/3/CameraTypeToggle/1/1")){
				//_mat.color = new Color( _mat.color.r,value,_mat.color.b);

				if (value == 1) {
				Camera.main.orthographic = false;

				} 

				if (value == 0) {

					Camera.main.orthographic = true;
				}
			}

			if(String.Equals(args.Address,"/3/CameraZoomOrtho")){
				//_mat.color = new Color( _mat.color.r,_mat.color.g,value);
				//if (value == 0) {
				//	Camera.main.orthographicSize = 2.61f; 
				//	// a sensible default 
				//	return;
				//}
				Camera.main.orthographicSize = value;

			}

			if(String.Equals(args.Address,"/3/CamOrthoDefaultSize")){


				// nice to interpolate / lerp this
				//Debug.Log ("In CamOrthoDefaultSize");
				float orthoSize = Camera.main.orthographicSize;

				iTween.ValueTo( Camera.main.gameObject, iTween.Hash(
					"from"    , orthoSize,
					"to"      , 2.61f,
					"time"    , CameraOrthoResetTime,
					"onUpdate", "UpdateCameraOrtho",
					"easeType", iTween.EaseType.easeOutSine
					));





				//Camera.main.orthographicSize = 2.61f;

				// reset position


				Vector3 currentPosition = Camera.main.transform.position;
				Vector3 originalPosition = new Vector3(0, 2.02f, -2.66f);

				iTween.ValueTo( Camera.main.gameObject, iTween.Hash(
					"from"    , currentPosition.x,
					"to"      , originalPosition.x,
					"time"    , CameraPositionResetTime,
					"onUpdate", "UpdateCameraX",
					"easeType", iTween.EaseType.easeOutSine
					));

				iTween.ValueTo( Camera.main.gameObject, iTween.Hash(
					"from"    , currentPosition.y,
					"to"      , originalPosition.y,
					"time"    , CameraPositionResetTime,
					"onUpdate", "UpdateCameraY",
					"easeType", iTween.EaseType.easeOutSine
					));

				//Camera.main.transform.position = iTween.Vector3Update(currentPosition, originalPosition, 2.0f);

				
			}

			if(String.Equals(args.Address,"/3/CameraZoomPerspective")){
				//_mat.color = new Color( _mat.color.r,_mat.color.g,value);
				//if (value == 0) {
				//	Camera.main.orthographicSize = 2.61f; 
				//	// a sensible default 
				//	return;
				//}
				Camera.main.fieldOfView = value;
				
			}
			


			if(String.Equals(args.Address,"/3/CamPerspectiveDefaultFOV")){
				
				Camera.main.fieldOfView = 70f;
				
			}


			// greyscale
			if(String.Equals(args.Address,"/3/FXGreyScaleToggle")){
				if (value == 1) {
					
					Camera.main.gameObject.GetComponent<GrayscaleEffect>().enabled = true;
					
				} else {
					
					Camera.main.gameObject.GetComponent<GrayscaleEffect>().enabled = false;
					
				}
			}

			// monochrome
			// Hangle monochrome on each object using ToggleMonoGreyScale

			// invert colours


			if(String.Equals(args.Address,"/3/FXInvertColors")){
				if (value == 1) {

					Camera.main.gameObject.GetComponent<InvertColors>().enabled = true;
				
				} else {

					Camera.main.gameObject.GetComponent<InvertColors>().enabled = false;

				}
			}


			// blur
			if(String.Equals(args.Address,"/3/FXBlur")){
			

				if (value >0) {
					Debug.Log("in blur >0");	

					
					Camera.main.gameObject.GetComponent<Blur>().enabled =  true;
					Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					Camera.main.gameObject.GetComponent<Blur>().blurSize =  value;
					//blurState=true;
					//blurSize = sliderValue;
					
				}
				
				if (value == 0)  {

					Camera.main.gameObject.GetComponent<Blur>().enabled =  false;
					Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					Camera.main.gameObject.GetComponent<Blur>().blurSize =  0.0f;
					//blurState = false;
					//blurSize = sliderValue;
					
					
				}

			
			}

			if(String.Equals(args.Address,"/3/FXMotionBlur")){

			if (value >0) {
				
				
				Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  true;
				Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount =  value;
				//motionBlurState = true;
				//motionBlurAmount = sliderValue;
				
				
			}
			
			if (value == 0)  {
				//Debug.Log ("/3/FXMotionBlur SLIDER OFF Value="+sliderValue); // you can use slider value = 0 as a toggle, if relevant.
				Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  false;
				//motionBlurState = false;
				//motionBlurAmount = sliderValue;
				
				
				
			}

			}
		

			if(String.Equals(args.Address,"/3/FXSepiaToggle")){

				if (value ==1) {

					Camera.main.gameObject.GetComponent<SepiaToneEffect>().enabled = true;
				}
				if (value == 0)  {
					Camera.main.gameObject.GetComponent<SepiaToneEffect>().enabled = false;
					
				}
			}

			if(String.Equals(args.Address,"/3/FXSunShaftsToggle")){

				if (value==1) {

					Camera.main.gameObject.GetComponent<SunShafts>().enabled = true;
				
				} else {

					Camera.main.gameObject.GetComponent<SunShafts>().enabled = false;

				}


			}

				
			if(String.Equals(args.Address,"/3/FXSunShaftsIntensity")){

			if (value >0) {
					// TODO Set FXSunShaftsToggle to true with an OSC Message
					//myMessage = new OSCMessage("/3/FXSunShaftsToggle", 1 ); // switch to the fourth tab in TouchOSC
					//transmitter.Send(myMessage);
					
					Camera.main.gameObject.GetComponent<SunShafts>().enabled = true;
					Camera.main.gameObject.GetComponent<SunShafts>().sunShaftIntensity = value;
					
					// Set the Shafts Caster to a prominent part of the active puppet [hardwired here to the body of the bird]
					// You could set it to an animated object to simulate randomish shadows on the screen
					
					
					// TODO create a way to address a key component of the main moving object... and make the effect below
					//Camera.main.gameObject.GetComponent<SunShafts>().sunTransform = object4.transform;
					
					
					// it would be great to control the color of the shafts.
					//Color col = myColorPicker.PickColorFromCoords(colorPickerTex, 10,10);
					//Debug.Log (col);
					//	Camera.main.gameObject.GetComponent<SunShafts>().sunColor = col;
					
				}
				if (value == 0)  {
				
					Camera.main.gameObject.GetComponent<SunShafts>().enabled = false;
					Camera.main.gameObject.GetComponent<SunShafts>().sunShaftIntensity = value;
				}

			}

				// TODO the colour picker
				// TODO sort out XY messages... 
				

			if(String.Equals(args.Address,"/3/FXNoiseToggle")){
				// TODO this simple switches between two states - experiment to see if any finer control would be helpful
				//	General Grain / Default Gentle Noise
				//	Intensity Multiplier = .4
				//	General  = .2
				//	Softness = 0 
				//	Soft Big Movement (like underwater / caustic reflections) 
				//	Intensity Multiplier = .62
				//	General  = .97 
				//	Softness = .98 
				if (value ==1) {
					//Debug.Log ("/3/FXNoiseToggle TRUE");
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().intensityMultiplier = .62f;
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().generalIntensity = 0.97f;
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().softness = 0.98f;
				}
				if (value == 0)  {
					//Debug.Log ("/3/FXNoiseToggle FALSE");
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().intensityMultiplier = .4f;
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().generalIntensity = 0.2f;
					Camera.main.gameObject.GetComponent<NoiseAndGrain>().softness = 0.0f;
					
					
				}




			}
			//* Vignetting - 
			//*						defaults	range
			//* 1. Amount=				 5.08		0-100
			//* 2. Blurred Corners=		 1			0-12	
			//* 3. Chromatic Aberration= 1.98		-80-80
			//* 
			//* 

			if(String.Equals(args.Address,"/3/FXVignetteBlur")){
				Camera.main.gameObject.GetComponent<Vignetting>().blur = value;
			}

			if(String.Equals(args.Address,"/3/FXVignetteChromatic")){
			
				if (value >0) {

					Camera.main.gameObject.GetComponent<Vignetting>().chromaticAberration = value;
					
					
				}
				
				if (value <0) {

					Camera.main.gameObject.GetComponent<Vignetting>().chromaticAberration = value;

				}

			}
			if(String.Equals(args.Address,"/3/FXVignetteSetDefaults")){
				Camera.main.gameObject.GetComponent<Vignetting>().chromaticAberration = 1.98f;
				Camera.main.gameObject.GetComponent<Vignetting>().intensity = 5.08f;
				Camera.main.gameObject.GetComponent<Vignetting>().blur = 1f;

				
			}
			if(String.Equals(args.Address,"/3/FXVignetteSize")){


					Camera.main.gameObject.GetComponent<Vignetting>().intensity = value;
					
					
			
			}

			if(String.Equals(args.Address,"/3/IrisLocationXYPad")){

				//int myXDivision =  screenWidth / 13; // 13 is the x size of the multipush array
				//int myYDivision = screenHeight / 10; // 10 is the y size of the multipush array
				//int myYOffset = myYDivision / 2;
				//int myXPos = (myXDivision*xPos); // centre of division
				//int myYPos = (myYDivision*yPos)+myYOffset; // centre of division REMOVED / 2 
				//int myStartX = 0;
				// this defines the bottom left hand corner of the visible screen (in world space)
				
				//Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(myXPos, myYPos, -2.1f));
				Debug.Log("Iris touched");
				iris.transform.position = new Vector3(value2+irisOffsetX, value+irisOffsetY, -2.1f);


			}

			if(String.Equals(args.Address,"/3/FXShaftColorPickerXY")){

				// TODO Set FXSunShaftsToggle to true with an OSC Message
				// TODO I've uncommented these to let one set the color without previewing that color - e.g. automatically turning on the effect.
				//myMessage = new OSCMessage("/3/FXSunShaftsToggle", 1 ); 
				//transmitter.Send(myMessage);
				//Camera.main.gameObject.GetComponent<SunShafts>().enabled = true;
				
				
				// Set the Shafts Caster to a prominent part of the active puppet [hardwired here to the body of the bird]
				// You could set it to an animated object to simulate randomish shadows on the screen
				
				// TODO create a way to address a key component of the main moving object... and make the effect below
				//Camera.main.gameObject.GetComponent<SunShafts>().sunTransform = object4.transform;
				
				// it would be great to control the color of the shafts. Here it is (!):
				// it would be great to included the image into the color picker in TouchOSC

				//TODO set a default for the color picker
				Color col = myColorPicker.PickColorFromCoords(colorPickerTex, value2,value);
				Camera.main.gameObject.GetComponent<SunShafts>().sunColor = col;

			}
			if(String.Equals(args.Address,"/3/FXSunShaftsIntensity")){

				Camera.main.gameObject.GetComponent<SunShafts>().enabled = true;
				Camera.main.gameObject.GetComponent<SunShafts>().sunShaftIntensity = value;


			}


		} // end of all address check

		

	}
}