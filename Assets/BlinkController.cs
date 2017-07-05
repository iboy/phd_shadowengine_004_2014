using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UniOSC{

	public class BlinkController : UniOSCEventTarget {
		public SpriteRenderer spriteToSwop;
		public Sprite eyeOpen;
		public Sprite eyeClosed;
		// Use this for initialization

		private bool toggleState;
		private void _Init(){

		}

		public override void OnEnable(){
			_Init();
			base.OnEnable();

		}

		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		if (Input.GetKeyDown("b")) {
		
				Debug.Log("doing a blink");
				spriteToSwop.sprite = eyeClosed;
			} 
		
		if (Input.GetKeyUp("b")) {
			
			Debug.Log("doing a blink");
			spriteToSwop.sprite = eyeOpen;
			} 
		}

		public override void OnOSCMessageReceived(UniOSCEventArgs args){
			
			if(args.Message.Data.Count <1)return;
			if(!( args.Message.Data[0]  is  System.Single))return;
			Debug.Log("OSC Blink message received");
			toggleState = Convert.ToBoolean(args.Message.Data[0]) ;
			//UpdateComponentState();

			if (toggleState == false) {

				spriteToSwop.sprite = eyeOpen;
			} else {
				spriteToSwop.sprite = eyeClosed;

			}
		}

	}

}