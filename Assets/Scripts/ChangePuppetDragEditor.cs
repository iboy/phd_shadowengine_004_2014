using UnityEngine;
using System.Collections;
using UnityEditor;



[CustomEditor(typeof(ChangePuppetDrag))]
public class ChangePuppetDragEditor : Editor
	 
{



	public override void OnInspectorGUI()
	{


		//scale = EditorGUI.Slider(Rect(5,5,150,20),scale,1, 100);

		ChangePuppetDrag myScript = (ChangePuppetDrag)target;
		//if(GUILayout.Button("Build Object"))
		//{
		//	myScript.ChangeDrag();
		//}

		//EditorGUILayout.LabelField ("Some help", "Some other text");

		//GUI.color = Color.yellow;
		EditorGUILayout.HelpBox(myScript.GetText(), MessageType.Info, true);
		//GUI.color = Color.white;
		myScript.rigidbodyMass = EditorGUILayout.Slider ("Rigidbody Mass", myScript.rigidbodyMass, 0.01f, 100);
		myScript.ChangeRigidbodyMass(myScript.rigidbodyMass);
		myScript.rigidbodyDrag = EditorGUILayout.Slider ("Rigidbody Drag", myScript.rigidbodyDrag, 0, 50);
		myScript.ChangeRigidbodyDrag(myScript.rigidbodyDrag);
		myScript.rigidbodyAngularDrag = EditorGUILayout.Slider ("Rigidbody Angular Drag", myScript.rigidbodyAngularDrag, 0, 50);
		myScript.ChangeRigidbodyAngularDrag(myScript.rigidbodyAngularDrag);


		DrawDefaultInspector();
	}



}