using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


	class ButtonSet001 : EditorWindow
	{
		
		

		bool myBool = true;
		bool blurBool = false;
		bool motionBlurBool = false;

		GameObject selected;
		


		GameObject BW_Mr_Fry;
		GameObject BW_Mr_Fry_Arm;
		GameObject BW_Mr_Fry_Body;
		GameObject BW_Mr_Fry_LLeg;
		GameObject BW_Mr_Fry_RLeg;
		GameObject BW_Mr_Fry_Pipe;
		GameObject BW_Mr_Fry_Pipe_Smoke;
		GameObject BW_Mr_Fry_Pipe_Sparks;
		GameObject BW_Mr_Fry_Pipe_CentreFire;
		GameObject BW_Mr_Fry_Pipe_TorchSmoke;

		// Add menu item named "My Window" to the Window menu
		[MenuItem ("ShadowEngine/Button Set 001 - Demo")]
		
		static void Init ()
		{
			//Debug.Log ("In ShadowEngine Window Init");
			
			// Get existing open window or if none, make a new one:
			ButtonSet001 window = (ButtonSet001)EditorWindow.GetWindow (typeof(ButtonSet001));
			window.name = "hello";
			window.Show ();
		
		}
		
		public static void  ShowWindow ()
		{
			// EditorWindow.GetWindow(typeof(ShadowEngine));
			
		}
		
		void OnGUI ()
		{
			
			// The actual window code goes here

		
			
			BW_Mr_Fry = GameObject.Find ("BW_Mr_Fry/MrFryC");
			BW_Mr_Fry_Body = GameObject.Find ("BW_Mr_Fry/MrFryC/BodyC");
			BW_Mr_Fry_Arm = GameObject.Find ("BW_Mr_Fry/MrFryC/ArmC");
			BW_Mr_Fry_LLeg = GameObject.Find ("BW_Mr_Fry/MrFryC/LegLC");
			BW_Mr_Fry_RLeg = GameObject.Find ("BW_Mr_Fry/MrFryC/LegRC");
			BW_Mr_Fry_Pipe = GameObject.Find ("BW_Mr_Fry/MrFryC/PipeC");
			BW_Mr_Fry_Pipe_Smoke = GameObject.Find ("BW_Mr_Fry/Pipe/Torch_fire");
			BW_Mr_Fry_Pipe_CentreFire = GameObject.Find ("BW_Mr_Fry/Pipe/Torch_fire/center_fire");
			BW_Mr_Fry_Pipe_Sparks = GameObject.Find ("BW_Mr_Fry/Pipe/Torch_fire/sparks");
			BW_Mr_Fry_Pipe_TorchSmoke = GameObject.Find ("BW_Mr_Fry/Pipe/Torch_fire/torch_smoke");
			

			
			GUILayout.Label ("Puppet Selection", EditorStyles.boldLabel);
			//GUI.color = Color.white;
			SetButtonColor (Color.white, Color.white, Color.white);
			

			EditorGUILayout.BeginHorizontal ();



			// BUTTON Select All
			if (GUILayout.Button ("All Puppets", GUILayout.Width (90), GUILayout.Height (60))) {
				DoAllPuppetSelection ();
			}
			

		

			
			
			
			EditorGUILayout.EndHorizontal ();

			
			
		

			
			EditorGUILayout.BeginHorizontal ();
			
		
			
			// BUTTON Mr Fry
			SetButtonColor (Color.yellow, Color.white, Color.white);
			if (GUILayout.Button ("Mr\nFry", GUILayout.Width (74), GUILayout.Height (60))) {
				DoSelection (BW_Mr_Fry);
			}
			
			// Start Button
			SetButtonColor (Color.blue, Color.white, Color.white);
			if (GUILayout.Button ("\u235F", GUILayout.Width (36), GUILayout.Height (60))) {
				
				
				RotatePuppet (BW_Mr_Fry);
				DoSelection (BW_Mr_Fry);
			}
			
			// End Button

			
			
			EditorGUILayout.EndHorizontal ();
			
			EditorGUILayout.BeginHorizontal ();
			SetButtonColor (Color.cyan, Color.white, Color.white);
			

			
			// select BW_Mr_Fry sub-controllers
			if (GUILayout.Button ("A", GUILayout.Width (16), GUILayout.Height (27))) {
				DoSelection (BW_Mr_Fry_Arm);
			}
			if (GUILayout.Button ("L", GUILayout.Width (16), GUILayout.Height (27))) {
				DoSelection (BW_Mr_Fry_LLeg);
			}
			if (GUILayout.Button ("L", GUILayout.Width (16), GUILayout.Height (27))) {
				DoSelection (BW_Mr_Fry_RLeg);
			}
			if (GUILayout.Button ("B", GUILayout.Width (16), GUILayout.Height (27))) {
				DoSelection (BW_Mr_Fry_Body);
			}
			if (GUILayout.Button ("P", GUILayout.Width (16), GUILayout.Height (27))) {
				DoSelection (BW_Mr_Fry_Pipe);
			}
			if (GUILayout.Button ("S", GUILayout.Width (16), GUILayout.Height (27))) {
				//DoSelection (BW_Mr_Fry_Pipe);
				
				
				if (BW_Mr_Fry_Pipe_Smoke.particleSystem.enableEmission == true) {
					
					BW_Mr_Fry_Pipe_Smoke.particleSystem.enableEmission = false;
				} else {
					BW_Mr_Fry_Pipe_Smoke.particleSystem.enableEmission = true;
				}
				
				if (BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission == true) {
					
					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission = false;
				} else {
					BW_Mr_Fry_Pipe_Sparks.particleSystem.enableEmission = true;
				}
				
				
				if (BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission == true) {
					
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = false;
				} else {
					BW_Mr_Fry_Pipe_CentreFire.particleSystem.enableEmission = true;
				}
				
				
				if (BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission == true) {
					
					BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = false;
				} else {
					BW_Mr_Fry_Pipe_TorchSmoke.particleSystem.enableEmission = true;
				}
				
				
				
				
				
			}
			
			

			EditorGUILayout.EndHorizontal ();
			
			
			
			
			EditorGUILayout.BeginHorizontal ();
			
			// BUTTON Deselect All
			
			SetButtonColor (Color.yellow, Color.white, Color.white);
			
			if (GUILayout.Button ("Deselect All", GUILayout.Width (90), GUILayout.Height (60))) {
				Selection.objects = new UnityEngine.Object[0];
			}
			
			
			// Set background, content and text color
			SetButtonColor (Color.red, Color.white, Color.white);
			//GUI.backgroundColor = Color.red;
			//GUI.contentColor = Color.white;
			//GUI.color= Color.white;
			
			
			if (EditorApplication.isPlaying) {
				SetButtonColor (Color.red, Color.white, Color.white);
				if (GUILayout.Button ("Stop", GUILayout.Width (90), GUILayout.Height (60))) {
					
					EditorApplication.isPlaying = false;
				}
			} else {
				SetButtonColor (Color.green, Color.white, Color.white);
				if (GUILayout.Button ("Play", GUILayout.Width (90), GUILayout.Height (60))) {
					
					EditorApplication.isPlaying = true;
				}
				
			}
			
			// Test Camera Effects Settings
			if (blurBool == true) {
				SetButtonColor (Color.red, Color.white, Color.white);
				if (GUILayout.Button ("No Blur", GUILayout.Width (90), GUILayout.Height (60))) {
					Camera.main.gameObject.GetComponent<Blur> ().enabled = false;
					Camera.main.gameObject.GetComponent<Blur> ().blurIterations = 1;
					Camera.main.gameObject.GetComponent<Blur> ().blurSize = 0.0f;
					blurBool = false;
					
					
					
					
				}
			} else {
				SetButtonColor (Color.green, Color.white, Color.white);
				if (GUILayout.Button ("Do Blur", GUILayout.Width (90), GUILayout.Height (60))) {
					Camera.main.gameObject.GetComponent<Blur> ().enabled = true;
					Camera.main.gameObject.GetComponent<Blur> ().blurIterations = 1;
					Camera.main.gameObject.GetComponent<Blur> ().blurSize = 0.4f;
					blurBool = true;
				}
				
			}
			// Test Camera Effects Settings
			if (motionBlurBool == true) {
				SetButtonColor (Color.red, Color.white, Color.white);
				if (GUILayout.Button ("No\nMotion Blur", GUILayout.Width (90), GUILayout.Height (60))) {
					Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = false;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<Blur>().blurSize =  0.0f;
					Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.0f;
					motionBlurBool = false;
					
					
					
					
				}
			} else {
				SetButtonColor (Color.green, Color.white, Color.white);
				if (GUILayout.Button ("Do\nMotion Blur", GUILayout.Width (90), GUILayout.Height (60))) {
					Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = true;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.6f;
					motionBlurBool = true;
				}
				
			}
			

			
			
			
			
			
			
			
			EditorGUILayout.EndHorizontal ();
			

			

		}
		
		
		
		
		
		
		// FUNCTIONS
		void RotatePuppet (GameObject go)
		{
			// might be a good idea to store the current selection
			
			Selection.objects = new UnityEngine.Object[0];
			
			GameObject parent = go.transform.parent.gameObject;
			
			
			
			List<GameObject> children = parent.GetChildren ();
			
			
			int count = children.Count;
			//GameObject[] newSelection2 = new GameObject[count];
			//for(int i = 0; i < count; i++)
			//{
			//	Debug.Log(i);
			//	newSelection2[i] = children.name;
			//}
			
			GameObject[] newSelection2 = new GameObject[count];
			int i = 0;
			foreach (GameObject str in children) {	
				newSelection2 [i] = str;
				//Undo.RegisterUndo(str, "Rotate " + str.name);
				
				if (str.transform.rotation.y == 0) {
					Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = true;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.6f;
					
					str.transform.eulerAngles = new Vector3 (0, 180f, 0);
					//Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  false;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount =  0.0f;
					
				} else { 
					Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = true;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					Camera.main.gameObject.GetComponent<MotionBlur> ().blurAmount = 0.6f;
					str.transform.eulerAngles = new  Vector3 (0, 0, 0);
					//Camera.main.gameObject.GetComponent<MotionBlur>().enabled =  false;
					//Camera.main.gameObject.GetComponent<Blur>().blurIterations =  1;
					//Camera.main.gameObject.GetComponent<MotionBlur>().blurAmount =  0.0f;
				}
				//Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = false;
				//Debug.Log(str);
				i++;
			}
			Selection.objects = newSelection2;
			// rotate children
			
			Camera.main.gameObject.GetComponent<MotionBlur> ().enabled = false;
			//Selection.objects = new UnityEngine.Object[0];
			
		}
		
		
		
		
		void DoSelection (GameObject go)
		{
			
			// reset selection
			Selection.objects = new UnityEngine.Object[0];
			
			// select object
			selected = go;
			Selection.activeObject = selected;
			EditorGUIUtility.PingObject (selected);
			
		}
		
		void DoSelectionAllLeftFacing ()
		{
			
			
			
		}
		
		void DoSelectionAllRightFacing ()
		{
			
			
			
		}
		// Select Sets of Elements - define the array of sets

		void DoAllPuppetSelection ()
		{
			
			// do multiple selections
			// reset current selections
			
			Selection.objects = new UnityEngine.Object[0];
			
			// edit array size as necessary
			GameObject[] newSelection = new GameObject[1];

			// add elements

			newSelection [0] = BW_Mr_Fry;

			
			
			Selection.objects = newSelection;
			
		}
		
		void SetButtonColor (Color buttonBackgroundColor, Color buttonContentColor, 
		                     Color buttonColor)
		{
			
			GUI.backgroundColor = buttonBackgroundColor;
			GUI.contentColor = buttonContentColor;
			GUI.color = buttonColor;
			
		}
	}