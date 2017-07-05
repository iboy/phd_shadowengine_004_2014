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
	/// Filter Address Template
	/// Rename class and file and edit
	/// </summary>
	[AddComponentMenu("UniOSC/FryPipeSmoke")]
		
		// Rename
		
	//[RequireComponent(typeof(MeshRenderer))]
	public class UniOSCFryPipeSmoke :  UniOSCEventTarget {



		float value;
		float value2;
	
		//public GameObject BW_Mr_Fry_Pipe_Smoke;
		public GameObject BW_Mr_Fry_Pipe_Sparks;
		public GameObject BW_Mr_Fry_Pipe_CentreFire;
		public GameObject BW_Mr_Fry_Pipe_TorchSmoke;
		public GameObject BW_Mr_Fry_Pipe_TorchFire;
		public string listenToSmokeAddress = "/4/pipeSmoke";
		public string listenToFlameAddress = "/4/pipeFlame";


		void Awake(){

		}

		private void _Init(){
			// Add addresses manually to this list
			receiveAllAddresses = false;
			_oscAddresses.Clear();
			_oscAddresses.Add(listenToFlameAddress);
			_oscAddresses.Add(listenToSmokeAddress);

		}


		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}

	
		public override void OnOSCMessageReceived(UniOSCEventArgs args){
		
			if(args.Message.Data.Count <1)return;


			if(!( args.Message.Data[0]  is  System.Single))return;
			 value = (float)args.Message.Data[0] ;
			if (args.Message.Data.Count ==2) {

				 value2 = (float)args.Message.Data[1] ;

			}

// Address Template
//			if(String.Equals(args.Address,"ADDRESS")){
//				if (value >0) {
//				}
//				if (value == 0)  {
//				}
//			}

			if(String.Equals(args.Address,listenToFlameAddress)){
			

				if (value == 1) {


					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission 	= true;
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = true;
					//BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = true;
					BW_Mr_Fry_Pipe_TorchFire.particleSystem.enableEmission 	= true;
					} else {
					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission 	= false;
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = false;
					//BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = false;
					BW_Mr_Fry_Pipe_TorchFire.particleSystem.enableEmission 	= false;


			}

			}


			if(String.Equals(args.Address,listenToSmokeAddress)){
				
				
				if (value > 0) {
					
					
					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission 	= false;
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = false;
					BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = true;
					BW_Mr_Fry_Pipe_TorchFire.particleSystem.enableEmission 	= false;


				} else {

					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission 	= false;
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = false;
					BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = false;
					BW_Mr_Fry_Pipe_TorchFire.particleSystem.enableEmission 	= false;
				}
					
				if (value > .3) {


					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission 	= true;
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = true;
					BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = true;
					BW_Mr_Fry_Pipe_TorchFire.particleSystem.enableEmission 	= true;

					BW_Mr_Fry_Pipe_CentreFire.particleSystem.startSize = value;
				}
			}

		} // end of all address check

		

	} // end of class
} // end of namespace