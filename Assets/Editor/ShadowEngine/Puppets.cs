//C# Example
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UniOSC
{
		class Puppets : EditorWindow
		{


				//string myString = "Hello World";
				//bool groupEnabled;
				//bool myBool = true;
				bool blurBool = false;
				bool motionBlurBool = false;
				bool doSnow = false;
				//float myFloat = 1.23f;
				GameObject selected;
				
				GameObject Static_Smoke;

				GameObject Snow;

				GameObject Fry_Sinatra;
				GameObject Fry_Sinatra_Arm;
				GameObject Fry_Sinatra_Body;
				GameObject Fry_Sinatra_LLeg;
				GameObject Fry_Sinatra_RLeg;
				GameObject Fry_Sinatra_Cigarette;
				GameObject Fry_Sinatra_Cigarette_Smoke;
				//GameObject Fry_Sinatra_Cigarette_Sparks;
				GameObject Fry_Sinatra_Cigarette_CentreFire;
				GameObject Fry_Sinatra_Cigarette_TorchSmoke;





				GameObject Fry_Coward;
				GameObject Fry_Coward_Arm;
				GameObject Fry_Coward_Body;
				GameObject Fry_Coward_LLeg;
				GameObject Fry_Coward_RLeg;
				GameObject Fry_Coward_Cigarette;
				GameObject Fry_Coward_Cigarette_Smoke;
				GameObject Fry_Coward_Cigarette_Sparks;
				GameObject Fry_Coward_Cigarette_CentreFire;
				GameObject Fry_Coward_Cigarette_TorchSmoke;

				GameObject Fry_Motorbike;
				GameObject Fry_Motorbike_BackC;
				GameObject Fry_Motorbike_CentreC;
				GameObject Fry_Motorbike_FrontC;
				GameObject Fry_Motorbike_Smoke;
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
				GameObject BW_Fry_Thatcher;
				GameObject BW_Fry_Thatcher_Arm;
				GameObject BW_Fry_Thatcher_Body;
				GameObject BW_Fry_Thatcher_Umbrella;
				GameObject BW_Swipes;
				GameObject BW_Swipes_Arm;
				GameObject BW_Swipes_Body;
				GameObject BW_Swipes_Leg;
				GameObject BW_Dick_Widemouth;
				GameObject BW_Dick_Widemouth_Body;
				GameObject BW_Dick_Widemouth_LowerBody;
				GameObject BW_Boy;
				GameObject BW_Boy_Arm;
				GameObject BW_Boy_Body;
				GameObject BW_Boy_LegL;
				GameObject BW_Boy_LegR;
				GameObject BW_John_Thomas;
				GameObject BW_John_Thomas_Arm;
				GameObject BW_John_Thomas_Body;
				GameObject BW_John_Thomas_Leg;
				GameObject BW_Mr_Brown;
				GameObject BW_Mr_Brown_Arm;
				GameObject BW_Mr_Brown_Body;
				GameObject BW_Mr_Brown_Leg;
				GameObject BW_Lord_Dundreary;
				GameObject BW_Lord_Dundreary_Arm;
				GameObject BW_Lord_Dundreary_Body;
				GameObject BW_Lord_Dundreary_Leg;
				GameObject BW_Grandfather_WhiteHead;
				GameObject BW_Grandfather_WhiteHead_Stick;
				GameObject BW_Grandfather_WhiteHead_Body;
				GameObject BW_Grandfather_WhiteHead_Leg;
				GameObject BW_Grandfather_WhiteHead_Hat;
				GameObject BW_Cap_in_hand;
				GameObject BW_Cap_in_hand_Arm;
				GameObject BW_Cap_in_hand_Leg;
				GameObject BW_3D_Bottle;
				GameObject BW_3D_Bottle_Arm;
				GameObject BW_3D_Bottle_Leg;
				GameObject BW_with_Violin;
				GameObject BW_with_Violin_Arm;
				GameObject BW_with_Violin_Leg;
				GameObject BW_Tozer_Dog;
				GameObject BW_Tozer_Dog_Leg;
				GameObject BW_Tozer_Dog_Body;
				GameObject BW_Mrs_Brown;
				GameObject BW_Mrs_Brown_Bushell;
				GameObject BW_Mary_Jane;
				GameObject BW_Mary_Jane_Pie;
				GameObject BW_Mary_Jane_Body;
				GameObject BW_Mrs_Martin;
				GameObject BW_Mrs_Martin_Arm;
				GameObject BW_Mrs_Martin_Body;
				GameObject BW_Jemima;
				GameObject BW_Jemima_Arm;
				GameObject BW_Jemima_Umbrella;
				GameObject BW_Policeman;
				GameObject BW_Policeman_Arm;
				GameObject BW_Policeman_LegR;
				GameObject BW_Policeman_LegL;
				GameObject BW_Policeman_Hat;


				//private GameObject go;

				// Add menu item named "My Window" to the Window menu
				[MenuItem ("ShadowEngine/Puppets Selection")]

				static void Init ()
				{
						Debug.Log ("In ShadowEngine Window Init");

						// Get existing open window or if none, make a new one:
						Puppets window = (Puppets)EditorWindow.GetWindow (typeof(Puppets));
						window.Show ();



				}

				public static void  ShowWindow ()
				{
						// EditorWindow.GetWindow(typeof(ShadowEngine));

				}

				void OnGUI ()
				{

			// The actual window code goes here

			Static_Smoke	= GameObject.Find ("Smoke - Static");


			Snow = GameObject.Find("SoftSnow - Shuriken");

			Fry_Sinatra	= GameObject.Find ("BW_Sinatra/MrSinatraC");
			Fry_Sinatra_Arm	= GameObject.Find ("BW_Sinatra/MrSinatraC/ArmC");
			Fry_Sinatra_Body	= GameObject.Find ("BW_Sinatra/MrSinatraC/BodyC");
			Fry_Sinatra_LLeg	= GameObject.Find ("BW_Sinatra/MrSinatraC/LegLC");
			Fry_Sinatra_RLeg	= GameObject.Find ("BW_Sinatra/MrSinatraC/LegRC");
			Fry_Sinatra_Cigarette	= GameObject.Find ("BW_Sinatra/MrSinatraC/CigaretteC");
			Fry_Sinatra_Cigarette_Smoke	= GameObject.Find ("BW_Sinatra/Fry_Sinatra_Cigarette/Torch_fire");
			//Fry_Sinatra_Cigarette_Sparks	= GameObject.Find ("BW_Sinatra/Fry_Sinatra_Cigarette/Torch_fire/sparks");
			Fry_Sinatra_Cigarette_CentreFire	= GameObject.Find ("BW_Sinatra/Fry_Sinatra_Cigarette/Torch_fire/center_fire");
			Fry_Sinatra_Cigarette_TorchSmoke	= GameObject.Find ("BW_Sinatra/Fry_Sinatra_Cigarette/Torch_fire/torch_smoke");



			Fry_Coward	= GameObject.Find ("BW_Noel_Coward/MrCowardC");
			Fry_Coward_Arm	= GameObject.Find ("BW_Noel_Coward/MrCowardC/ArmC");
			Fry_Coward_Body	= GameObject.Find ("BW_Noel_Coward/MrCowardC/BodyC");
			Fry_Coward_LLeg	= GameObject.Find ("BW_Noel_Coward/MrCowardC/LegLC");
			Fry_Coward_RLeg	= GameObject.Find ("BW_Noel_Coward/MrCowardC/LegRC");
			Fry_Coward_Cigarette	= GameObject.Find ("BW_Noel_Coward/MrCowardC/CigaretteC");
			Fry_Coward_Cigarette_Smoke	= GameObject.Find ("BW_Noel_Coward/Fry_Noel_Coward_Cigarette/Torch_fire");
			//Fry_Coward_Cigarette_Sparks	= GameObject.Find ("BW_Noel_Coward/Fry_Noel_Coward_Cigarette/Torch_fire/sparks");
			Fry_Coward_Cigarette_CentreFire	= GameObject.Find ("BW_Noel_Coward/Fry_Noel_Coward_Cigarette/Torch_fire/center_fire");
			Fry_Coward_Cigarette_TorchSmoke	= GameObject.Find ("BW_Noel_Coward/Fry_Noel_Coward_Cigarette/Torch_fire/torch_smoke");
			




						Fry_Motorbike = GameObject.Find ("Fry_Motorbike/MotorbikeC");	
						Fry_Motorbike_BackC = GameObject.Find ("Fry_Motorbike/MotorbikeC/BackC");
						Fry_Motorbike_CentreC = GameObject.Find ("Fry_Motorbike/MotorbikeC/CentreC");
						Fry_Motorbike_FrontC = GameObject.Find ("Fry_Motorbike/MotorbikeC/FrontC");
						Fry_Motorbike_Smoke = GameObject.Find ("Fry_Motorbike/BW_Fry_Motorbike_Frame/Oil_smoke");
                  
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


						BW_Fry_Thatcher = GameObject.Find ("Fry_Thatcher/ThatcherC");
						BW_Fry_Thatcher_Arm = GameObject.Find ("Fry_Thatcher/ThatcherC/ArmC");
						BW_Fry_Thatcher_Body = GameObject.Find ("Fry_Thatcher/ThatcherC/BodyC");
						BW_Fry_Thatcher_Umbrella = GameObject.Find ("Fry_Thatcher/ThatcherC/BrollyC");


						BW_Dick_Widemouth = GameObject.Find ("BW_Dick_Widemouth/DickC");
						BW_Dick_Widemouth_Body = GameObject.Find ("BW_Dick_Widemouth/DickC/BodyC");
						BW_Dick_Widemouth_LowerBody = GameObject.Find ("BW_Dick_Widemouth/DickC/LowerBodyC");
			
						BW_Swipes = GameObject.Find ("BW_Swipes/SwipesC");
						BW_Swipes_Arm = GameObject.Find ("BW_Swipes/SwipesC/ArmC");
						BW_Swipes_Body = GameObject.Find ("BW_Swipes/SwipesC/BodyC");
						BW_Swipes_Leg = GameObject.Find ("BW_Swipes/SwipesC/LegC");

						BW_Boy = GameObject.Find ("BW_Boy/BoyC");
						BW_Boy_Arm = GameObject.Find ("BW_Boy/BoyC/ArmC");
						BW_Boy_Body = GameObject.Find ("BW_Boy/BoyC/BodyC");
						BW_Boy_LegL = GameObject.Find ("BW_Boy/BoyC/LegLC");
						BW_Boy_LegR = GameObject.Find ("BW_Boy/BoyC/LegRC");
			
						BW_John_Thomas = GameObject.Find ("BW_John_Thomas/JohnC");
						BW_John_Thomas_Arm = GameObject.Find ("BW_John_Thomas/JohnC/ArmC");
						BW_John_Thomas_Body = GameObject.Find ("BW_John_Thomas/JohnC/BodyC");
						BW_John_Thomas_Leg = GameObject.Find ("BW_John_Thomas/JohnC/LegC");

						BW_Mr_Brown = GameObject.Find ("BW_Mr_Brown/MrBrownC");
						BW_Mr_Brown_Arm = GameObject.Find ("BW_Mr_Brown/MrBrownC/ArmC");
						BW_Mr_Brown_Body = GameObject.Find ("BW_Mr_Brown/MrBrownC/BodyC");
						BW_Mr_Brown_Leg = GameObject.Find ("BW_Mr_Brown/MrBrownC/LegC");

						BW_Lord_Dundreary = GameObject.Find ("BW_Lord_Dundreary/LordC");
						BW_Lord_Dundreary_Arm = GameObject.Find ("BW_Lord_Dundreary/LordC/ArmC");
						BW_Lord_Dundreary_Body = GameObject.Find ("BW_Lord_Dundreary/LordC/BodyC");
						BW_Lord_Dundreary_Leg = GameObject.Find ("BW_Lord_Dundreary/LordC/LegC");

						BW_Grandfather_WhiteHead = GameObject.Find ("BW_Grandfather_WhiteHead/GrandpaC");
						BW_Grandfather_WhiteHead_Stick = GameObject.Find ("BW_Grandfather_WhiteHead/GrandpaC/StickC");
						BW_Grandfather_WhiteHead_Body = GameObject.Find ("BW_Grandfather_WhiteHead/GrandpadC/BodyC");
						BW_Grandfather_WhiteHead_Leg = GameObject.Find ("BW_Grandfather_WhiteHead/GrandpaC/LegC");
						BW_Grandfather_WhiteHead_Hat = GameObject.Find ("BW_Grandfather_WhiteHead/GrandpaC/HatC");

						BW_Cap_in_hand = GameObject.Find ("BW_Cap_in_hand/BillyC");
						BW_Cap_in_hand_Arm = GameObject.Find ("BW_Cap_in_hand/BillyC/ArmC");
						BW_Cap_in_hand_Leg = GameObject.Find ("BW_Cap_in_hand/BillyC/LegC");

						BW_3D_Bottle = GameObject.Find ("BW_3D_Bottle/BillyC");
						BW_3D_Bottle_Arm = GameObject.Find ("BW_3D_Bottle/BillyC/ArmC");
						BW_3D_Bottle_Leg = GameObject.Find ("BW_3D_Bottle/BillyC/LegC");

						BW_with_Violin = GameObject.Find ("BW_with_Violin/BillyC");
						BW_with_Violin_Arm = GameObject.Find ("BW_with_Violin/BillyC/ArmC");
						BW_with_Violin_Leg = GameObject.Find ("BW_with_Violin/BillyC/LegC");

						BW_Tozer_Dog = GameObject.Find ("BW_Tozer_Dog/TozerC");
						BW_Tozer_Dog_Leg = GameObject.Find ("BW_Tozer_Dog/TozerC/LegC");
						BW_Tozer_Dog_Body = GameObject.Find ("BW_Tozer_Dog/TozerC/BodyC");
		
						BW_Mrs_Brown = GameObject.Find ("BW_Mrs_Brown/MrsBrownC");
						BW_Mrs_Brown_Bushell = GameObject.Find ("BW_Mrs_Brown/MrsBrownC/BushellC");

						BW_Mary_Jane = GameObject.Find ("BW_Mary_Jane/MaryJaneC");
						BW_Mary_Jane_Pie = GameObject.Find ("BW_Mary_Jane/MaryJaneC/PieC");
						BW_Mary_Jane_Body = GameObject.Find ("BW_Mary_Jane/MaryJaneC/BodyC");

						BW_Mrs_Martin = GameObject.Find ("BW_Mrs_Martin/MrsMartinC");
						BW_Mrs_Martin_Arm = GameObject.Find ("BW_Mrs_Martin/MrsMartinC/ArmC");
						BW_Mrs_Martin_Body = GameObject.Find ("BW_Mrs_Martin/MrsMartinC/BodyC");

						BW_Jemima = GameObject.Find ("BW_Jemima/JemC");
						BW_Jemima_Umbrella = GameObject.Find ("BW_Jemima/JemC/BrollyC");
						BW_Jemima_Arm = GameObject.Find ("BW_Jemima/JemC/ArmC");

						BW_Policeman = GameObject.Find ("BW_Policeman/PoliceC");
						BW_Policeman_Arm = GameObject.Find ("BW_Policeman/PoliceC/ArmC");
						BW_Policeman_LegR = GameObject.Find ("BW_Policeman/PoliceC/LegRC");
						BW_Policeman_LegL = GameObject.Find ("BW_Policeman/PoliceC/LegLC");
						BW_Policeman_Hat = GameObject.Find ("BW_Policeman/PoliceC/HatC");

						GUILayout.Label ("Puppet Selection", EditorStyles.boldLabel);
						//GUI.color = Color.white;
						SetButtonColor (Color.white, Color.white, Color.white);

						//GameObject[] objs = Selection.gameObjects;
						EditorGUILayout.BeginHorizontal ();

						// BUTTON Billy Waters Set
						if (GUILayout.Button ("Billy Waters\nAll Puppets", GUILayout.Width (90), GUILayout.Height (60))) {
								DoBillyAllPuppetSelection ();
						}

						// BUTTON BW Violin
						if (GUILayout.Button ("BW Violin", GUILayout.Width (70), GUILayout.Height (60))) {
								DoSelection (BW_with_Violin);
						}
						SetButtonColor (Color.blue, Color.white, Color.white);

						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
								RotatePuppet (BW_with_Violin);
								DoSelection (BW_with_Violin);
						}
						SetButtonColor (Color.white, Color.white, Color.white);

						// BUTTON BW Bottle
						if (GUILayout.Button ("BW Bottle", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_3D_Bottle);
						}
			
						SetButtonColor (Color.blue, Color.white, Color.white);
		
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
								RotatePuppet (BW_3D_Bottle);
								DoSelection (BW_3D_Bottle);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// BUTTON BW Cap in hand
						if (GUILayout.Button ("BW Cap", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Cap_in_hand);
						}

						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
								RotatePuppet (BW_Cap_in_hand);
								DoSelection (BW_Cap_in_hand);
						}
						SetButtonColor (Color.yellow, Color.white, Color.white);
						// End Button

						// BUTTON Tozer Dog
						if (GUILayout.Button ("Tozer Dog", GUILayout.Width (66), GUILayout.Height (60))) {
								DoSelection (BW_Tozer_Dog);
						}

						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {


								RotatePuppet (BW_Tozer_Dog);
								DoSelection (BW_Tozer_Dog);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button

	

						EditorGUILayout.EndHorizontal ();


// NEW ROW SMALL BUTTONS

						EditorGUILayout.BeginHorizontal ();
						// Select Full Set Switches Left and Right Figures

						SetButtonColor (Color.cyan, Color.white, Color.white);

						if (GUILayout.Button ("Left", GUILayout.Width (43), GUILayout.Height (27))) {
								DoSelectionAllLeftFacing ();
						}
						if (GUILayout.Button ("Right", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelectionAllRightFacing ();
						}

						// select BW Violin sub-controllers
						if (GUILayout.Button ("Arm", GUILayout.Width (43), GUILayout.Height (27))) {
								DoSelection (BW_with_Violin_Arm);
						}
						if (GUILayout.Button ("Leg", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_with_Violin_Leg);
						}
						// select BW Bottle sub-controllers
						if (GUILayout.Button ("Arm", GUILayout.Width (43), GUILayout.Height (27))) {
								DoSelection (BW_3D_Bottle_Arm);
						}
						if (GUILayout.Button ("Leg", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_3D_Bottle_Leg);
						}

						GUILayout.Space (2);

						// select BW Cap in Hand sub-controllers
						if (GUILayout.Button ("Arm", GUILayout.Width (43), GUILayout.Height (27))) {
								DoSelection (BW_Cap_in_hand_Arm);
						}
						if (GUILayout.Button ("Leg", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Cap_in_hand_Leg);
						}

						// select Tozer Dog sub-controllers
						if (GUILayout.Button ("Paw", GUILayout.Width (42), GUILayout.Height (27))) {
								DoSelection (BW_Tozer_Dog_Leg);
						}
						if (GUILayout.Button ("Body", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Tozer_Dog_Body);
						}


						EditorGUILayout.EndHorizontal ();


// NEW ROW BIG BUTTONS
						EditorGUILayout.BeginHorizontal ();


						SetButtonColor (Color.white, Color.white, Color.white);
		


						// BUTTON BW_Mrs_Brown
						if (GUILayout.Button ("Mrs Brown", GUILayout.Width (66), GUILayout.Height (60))) {
			
								DoSelection (BW_Mrs_Brown);
						}
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
			
			
								RotatePuppet (BW_Mrs_Brown);
								DoSelection (BW_Mrs_Brown);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button

						// BUTTON Mrs Martin
						if (GUILayout.Button ("Mrs\nMartin", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Mrs_Martin);
						}


						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
								RotatePuppet (BW_Mrs_Martin);
								DoSelection (BW_Mrs_Martin);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button
	
						// BUTTON BW_Mary_Jane
						if (GUILayout.Button ("Mary-Jane", GUILayout.Width (66), GUILayout.Height (60))) {
								DoSelection (BW_Mary_Jane);
						}
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Mary_Jane);
								DoSelection (BW_Mary_Jane);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button
			
			
			
						// BUTTON BW_Jemima
						if (GUILayout.Button ("Jemima", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Jemima);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Jemima);
								DoSelection (BW_Jemima);
						}
						SetButtonColor (Color.yellow, Color.white, Color.white);
						// End Button
			
						// BUTTON BW_Policeman
						if (GUILayout.Button ("Policeman", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Policeman);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Policeman);
								DoSelection (BW_Policeman);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button


		

						EditorGUILayout.EndHorizontal ();


						EditorGUILayout.BeginHorizontal ();

						SetButtonColor (Color.cyan, Color.white, Color.white);

						// select Mrs Brown  sub-controllers
						if (GUILayout.Button ("Bushell", GUILayout.Width (88), GUILayout.Height (27))) {
								DoSelection (BW_Mrs_Brown_Bushell);
						}
		
						// select Mrs Martin sub-controllers
						if (GUILayout.Button ("Arm", GUILayout.Width (42), GUILayout.Height (27))) {
								DoSelection (BW_Mrs_Martin_Arm);
						}

						if (GUILayout.Button ("Body", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Mrs_Martin_Body);
						}
		

						GUILayout.Space (2);
						// select Mary-Jane sub-controllers
						if (GUILayout.Button ("Pie", GUILayout.Width (42), GUILayout.Height (27))) {
								DoSelection (BW_Mary_Jane_Pie);
						}
						if (GUILayout.Button ("Body", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Mary_Jane_Body);
						}
		
						// select Jemima sub-controllers
						if (GUILayout.Button ("Brolly", GUILayout.Width (42), GUILayout.Height (27))) {
								DoSelection (BW_Jemima_Umbrella);
						}
						if (GUILayout.Button ("Arm", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Jemima_Arm);
						}

						// select Policeman sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Policeman_Arm);
						}
						if (GUILayout.Button ("L", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Policeman_LegL);
						}
						if (GUILayout.Button ("R", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Policeman_LegR);
						}
						if (GUILayout.Button ("H", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Policeman_Hat);
						}


						EditorGUILayout.EndHorizontal ();

// Big row 
						EditorGUILayout.BeginHorizontal ();
						SetButtonColor (Color.white, Color.white, Color.white);
						// BUTTON BW_Lord_Dundreary
						if (GUILayout.Button ("The Lord", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Lord_Dundreary);
						}
			
// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Lord_Dundreary);
								DoSelection (BW_Lord_Dundreary);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
// End Button
		
// BUTTON BW_Grandfather_WhiteHead
						if (GUILayout.Button ("Grand-\nFather", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Grandfather_WhiteHead);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Grandfather_WhiteHead);
								DoSelection (BW_Grandfather_WhiteHead);
						}

						// End Button
						// BUTTON BW_Mr_Brown
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("Mr Brown", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Mr_Brown);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Mr_Brown);
								DoSelection (BW_Mr_Brown);
						}
			
						// End Button

						// BUTTON BW_Boy
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("The Boy", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Boy);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Boy);
								DoSelection (BW_Boy);
						}
			
						// End Button

						// BUTTON Dick Widemouth
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("Dick\nWide\nmouth", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Dick_Widemouth);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Dick_Widemouth);
								DoSelection (BW_Dick_Widemouth);
						}
			
						// End Button
			
						EditorGUILayout.EndHorizontal ();

// Small row
						SetButtonColor (Color.cyan, Color.white, Color.white);
						EditorGUILayout.BeginHorizontal ();
			
						// select BW_Lord_Dundreary sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Lord_Dundreary_Arm);
						}
						if (GUILayout.Button ("L", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Lord_Dundreary_Leg);
						}
						if (GUILayout.Button ("B", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Lord_Dundreary_Body);
						}


						// select Grandfather sub-controllers
						if (GUILayout.Button ("H", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Grandfather_WhiteHead_Hat);
						}
						if (GUILayout.Button ("B", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Grandfather_WhiteHead_Body);
						}
						if (GUILayout.Button ("S", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Grandfather_WhiteHead_Stick);
						}
						if (GUILayout.Button ("L", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Grandfather_WhiteHead_Leg);
						}


						// select Mr Brown sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Mr_Brown_Arm);
						}
						if (GUILayout.Button ("L", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Mr_Brown_Leg);
						}
						if (GUILayout.Button ("B", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Mr_Brown_Body);
						}

						// select Boy sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Boy_Arm);
						}
						if (GUILayout.Button ("LL", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Boy_LegL);
						}
					
						if (GUILayout.Button ("RL", GUILayout.Width (21), GUILayout.Height (27))) {
								DoSelection (BW_Boy_LegR);
						}
						if (GUILayout.Button ("B", GUILayout.Width (20), GUILayout.Height (27))) {
								DoSelection (BW_Boy_Body);
						}

						// select Dick Widemouth sub-controllers

						if (GUILayout.Button ("B", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Dick_Widemouth_Body);
						}
						if (GUILayout.Button ("LB", GUILayout.Width (44), GUILayout.Height (27))) {
								DoSelection (BW_Dick_Widemouth_LowerBody);
						}
			
			
			



						EditorGUILayout.EndHorizontal ();
			
						EditorGUILayout.BeginHorizontal ();
		
						// BUTTON Swipes
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("Swipes", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Swipes);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Swipes);
								DoSelection (BW_Swipes);
						}
			
						// End Button

						// BUTTON John Thomas
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("John\nThomas", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_John_Thomas);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_John_Thomas);
								DoSelection (BW_John_Thomas);
						}
			
						// End Button
			
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
			//GUILayout.Space (6);
						// BUTTON Thatcher
						SetButtonColor (Color.white, Color.white, Color.white);
						if (GUILayout.Button ("Thatcher", GUILayout.Width (68), GUILayout.Height (60))) {
								DoSelection (BW_Fry_Thatcher);
						}
			
						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				
				
								RotatePuppet (BW_Fry_Thatcher);
								DoSelection (BW_Fry_Thatcher);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button
						//GUILayout.Space (4);
						// BUTTON Motorbike
						SetButtonColor (Color.yellow, Color.white, Color.white);
						if (GUILayout.Button ("Motorbike", GUILayout.Width (64), GUILayout.Height (60))) {
								DoSelection (Fry_Motorbike);
						}

						// Start Button
						SetButtonColor (Color.blue, Color.white, Color.white);
						if (GUILayout.Button ("\u235F", GUILayout.Width (20), GUILayout.Height (60))) {
				

								RotatePuppet (Fry_Motorbike);
								DoSelection (Fry_Motorbike);
						}
						SetButtonColor (Color.white, Color.white, Color.white);
						// End Button

	
		
						EditorGUILayout.EndHorizontal ();

						EditorGUILayout.BeginHorizontal ();
						SetButtonColor (Color.cyan, Color.white, Color.white);



						// select BW_Swipes sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Swipes_Arm);
						}
						if (GUILayout.Button ("L", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Swipes_Leg);
						}
						if (GUILayout.Button ("B", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Swipes_Body);
						}



						// select BW_John_Thomas sub-controllers
						if (GUILayout.Button ("A", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_John_Thomas_Arm);
						}
						if (GUILayout.Button ("L", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_John_Thomas_Leg);
						}
						if (GUILayout.Button ("B", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_John_Thomas_Body);
						}


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
			
			
			
			
			// select Thatcher sub-controllers
						if (GUILayout.Button ("B", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Fry_Thatcher_Body);
						}
						if (GUILayout.Button ("A", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Fry_Thatcher_Arm);
						}
						if (GUILayout.Button ("U", GUILayout.Width (28), GUILayout.Height (27))) {
								DoSelection (BW_Fry_Thatcher_Umbrella);
						}

						// select Motorbike sub-controllers
						if (GUILayout.Button ("B", GUILayout.Width (18), GUILayout.Height (27))) {
							DoSelection (Fry_Motorbike_BackC);
						}
						if (GUILayout.Button ("C", GUILayout.Width (18), GUILayout.Height (27))) {
							DoSelection (Fry_Motorbike_CentreC);
						}
						if (GUILayout.Button ("F", GUILayout.Width (18), GUILayout.Height (27))) {
							DoSelection (Fry_Motorbike_FrontC);
						}
						if (GUILayout.Button ("S", GUILayout.Width (18), GUILayout.Height (27))) {
							//DoSelection (Fry_Motorbike_Smoke);
							if (Fry_Motorbike_Smoke.particleSystem.enableEmission == true) {
							
											//Fry_Motorbike_Smoke.SetActive(false);
								Fry_Motorbike_Smoke.particleSystem.enableEmission = false;
										} else {
								Fry_Motorbike_Smoke.particleSystem.enableEmission = true;
								//Fry_Motorbike_Smoke.renderer.enabled = true;
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


						SetButtonColor (Color.yellow, Color.white, Color.white);
						if (GUILayout.Button ("Select\nFry and Bike", GUILayout.Width (90), GUILayout.Height (60))) {
							FryAndMotorbikeSelection();
						}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			SetButtonColor (Color.white, Color.white, Color.white);
			if (GUILayout.Button ("Select\nThatcher\nand Bike", GUILayout.Width (90), GUILayout.Height (60))) {
				ThatcherAndMotorbikeSelection();
			}


			// BUTTON Mr Fry
			SetButtonColor (Color.yellow, Color.white, Color.white);
			if (GUILayout.Button ("Mr\nCoward", GUILayout.Width (74), GUILayout.Height (60))) {
				DoSelection (Fry_Coward);
			}
			
			// Start Button
			SetButtonColor (Color.blue, Color.white, Color.white);
			if (GUILayout.Button ("\u235F", GUILayout.Width (50), GUILayout.Height (60))) {
				
				
				RotatePuppet (Fry_Coward);
				DoSelection (Fry_Coward);
			}
			//GUILayout.Space(2);
			// Start Button Sinatra
			SetButtonColor (Color.yellow, Color.white, Color.white);
			if (GUILayout.Button ("Select\nSinatra", GUILayout.Width (74), GUILayout.Height (60))) {
				DoSelection (Fry_Sinatra);
			}
			
			SetButtonColor (Color.blue, Color.white, Color.white);
			if (GUILayout.Button ("\u235F", GUILayout.Width (50), GUILayout.Height (60))) {
				
				
				RotatePuppet (Fry_Sinatra);
				DoSelection (Fry_Sinatra);
			}



			SetButtonColor (Color.white, Color.white, Color.white);
			if (GUILayout.Button ("Select\nStatic\nSmoke", GUILayout.Width (45), GUILayout.Height (60))) {
				DoSelection (Static_Smoke);
			}



		


			// Do Particle Snow
			if (doSnow == false) {
				SetButtonColor (Color.green, Color.white, Color.white);
				if (GUILayout.Button ("Start\nSnow", GUILayout.Width (60), GUILayout.Height (60))) {
					ParticleSystem mySnow = Snow.particleSystem;
					//Snow.particleSystem.Stop();
					mySnow.Play();
					mySnow.enableEmission = true;
					doSnow = true;
					
					
					
					
				}
			} else {
				SetButtonColor (Color.red, Color.white, Color.white);
				if (GUILayout.Button ("Stop\nSnow", GUILayout.Width (60), GUILayout.Height (60))) {
					ParticleSystem mySnow = Snow.particleSystem;
					mySnow.Stop();
					mySnow.enableEmission  = false;

					doSnow = false;
				}
				
			}









			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();

			GUILayout.Space(96);
			SetButtonColor (Color.cyan, Color.white, Color.white);
			// select Mr Coward sub-controllers
			if (GUILayout.Button ("A", GUILayout.Width (18), GUILayout.Height (27))) {
				DoSelection (Fry_Coward_Arm);
			}
			if (GUILayout.Button ("L", GUILayout.Width (18), GUILayout.Height (27))) {
				DoSelection (Fry_Coward_LLeg);
			}
			if (GUILayout.Button ("R", GUILayout.Width (18), GUILayout.Height (27))) {
				DoSelection (Fry_Coward_RLeg);
			}
			if (GUILayout.Button ("B", GUILayout.Width (18), GUILayout.Height (27))) {
				DoSelection (Fry_Coward_Body);
			}
			if (GUILayout.Button ("C", GUILayout.Width (18), GUILayout.Height (27))) {
				DoSelection (Fry_Coward_Cigarette);
			}
			if (GUILayout.Button ("S", GUILayout.Width (18), GUILayout.Height (27))) {
				//DoSelection (BW_Mr_Fry_Pipe);
				
				
				if (Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission == true) {
					
					Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission = false;
				} else {
					Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission = true;
				}
				
				if (Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission == true) {
					
					Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission = false;
				} else {
					Fry_Coward_Cigarette_Smoke.particleSystem.enableEmission = true;
				}
				
				
				if (Fry_Coward_Cigarette_CentreFire.particleSystem.enableEmission == true) {
					
					Fry_Coward_Cigarette_CentreFire.particleSystem.enableEmission = false;
				} else {
					Fry_Coward_Cigarette_CentreFire.particleSystem.enableEmission = true;
				}
				
				
				if (Fry_Coward_Cigarette_TorchSmoke.particleSystem.enableEmission == true) {
					
					Fry_Coward_Cigarette_TorchSmoke.particleSystem.enableEmission = false;
				} else {
					Fry_Coward_Cigarette_TorchSmoke.particleSystem.enableEmission = true;
				}
				

			}
			

			GUILayout.Space(4);
				SetButtonColor (Color.cyan, Color.white, Color.white);
				// select Mr Coward sub-controllers
				if (GUILayout.Button ("A", GUILayout.Width (18), GUILayout.Height (27))) {
					DoSelection (Fry_Sinatra_Arm);
				}
				if (GUILayout.Button ("L", GUILayout.Width (18), GUILayout.Height (27))) {
					DoSelection (Fry_Sinatra_LLeg);
				}
				if (GUILayout.Button ("R", GUILayout.Width (18), GUILayout.Height (27))) {
					DoSelection (Fry_Sinatra_RLeg);
				}
				if (GUILayout.Button ("B", GUILayout.Width (18), GUILayout.Height (27))) {
					DoSelection (Fry_Sinatra_Body);
				}
				if (GUILayout.Button ("C", GUILayout.Width (18), GUILayout.Height (27))) {
					DoSelection (Fry_Sinatra_Cigarette);
				}
				if (GUILayout.Button ("S", GUILayout.Width (18), GUILayout.Height (27))) {
					//DoSelection (BW_Mr_Fry_Pipe);
					
					
					if (Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission == true) {
						
						Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission = false;
					} else {
						Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission = true;
					}
					
					if (Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission == true) {
						
						Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission = false;
					} else {
						Fry_Sinatra_Cigarette_Smoke.particleSystem.enableEmission = true;
					}
					
					
					if (Fry_Sinatra_Cigarette_CentreFire.particleSystem.enableEmission == true) {
						
						Fry_Sinatra_Cigarette_CentreFire.particleSystem.enableEmission = false;
					} else {
						Fry_Sinatra_Cigarette_CentreFire.particleSystem.enableEmission = true;
					}
					
					
					if (Fry_Sinatra_Cigarette_TorchSmoke.particleSystem.enableEmission == true) {
						
						Fry_Sinatra_Cigarette_TorchSmoke.particleSystem.enableEmission = false;
					} else {
						Fry_Sinatra_Cigarette_TorchSmoke.particleSystem.enableEmission = true;
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
// Select All
		void FryAndMotorbikeSelection ()
		{
			Selection.objects = new UnityEngine.Object[0];
			
			
			GameObject[] newSelection = new GameObject[2];
			newSelection [0] = BW_Mr_Fry;
			//newSelection [0] = BW_Fry_Thatcher;
			newSelection [1] = Fry_Motorbike;


			Selection.objects = newSelection;
			
		}


		void ThatcherAndMotorbikeSelection ()
		{
			Selection.objects = new UnityEngine.Object[0];
			
			
			GameObject[] newSelection = new GameObject[2];
			//newSelection [0] = BW_Mr_Fry;
			newSelection [0] = BW_Fry_Thatcher;
			newSelection [1] = Fry_Motorbike;
			
			
			Selection.objects = newSelection;
			
		}
		void DoBillyAllPuppetSelection ()
				{

						// do multiple selections
						// reset current selections

						Selection.objects = new UnityEngine.Object[0];


						GameObject[] newSelection = new GameObject[16];

						newSelection [0] = BW_with_Violin;
						newSelection [1] = BW_Tozer_Dog;		
						newSelection [2] = BW_Mrs_Brown;
						newSelection [3] = BW_Mary_Jane;
						newSelection [4] = BW_Mrs_Martin;
						newSelection [5] = BW_Jemima;		
						newSelection [6] = BW_Policeman;	
						newSelection [7] = BW_3D_Bottle;
						newSelection [8] = BW_Cap_in_hand;
						newSelection [9] = BW_Grandfather_WhiteHead;
						newSelection [10] = BW_John_Thomas;
						newSelection [11] = BW_Mr_Brown;
						newSelection [12] = BW_Lord_Dundreary;
						newSelection [13] = BW_Boy;
						newSelection [14] = BW_Dick_Widemouth;
						newSelection [15] = BW_Swipes;
						//newSelection [16] = BW_Mr_Fry;
						//newSelection [17] = BW_Fry_Thatcher;
						//newSelection [18] = Fry_Motorbike;


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

}