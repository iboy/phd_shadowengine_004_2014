using UnityEngine;
using System.Collections;
using UnityEditor;



[CustomEditor(typeof(ChangeSpringJointProperties))]
public class ChangeSpringJointPropertiesEditor : Editor
	 
{



	public override void OnInspectorGUI()
	{


		//scale = EditorGUI.Slider(Rect(5,5,150,20),scale,1, 100);

		ChangeSpringJointProperties myScript = (ChangeSpringJointProperties)target;
		//if(GUILayout.Button("Build Object"))
		//{
		//	myScript.ChangeDrag();
		//}

		//EditorGUILayout.LabelField ("Some help", "Some other text");

		//GUI.color = Color.yellow;
		EditorGUILayout.HelpBox(myScript.GetText(), MessageType.Info, true);
		//GUI.color = Color.white;
		myScript.springjointSpring = EditorGUILayout.Slider ("Spring", myScript.springjointSpring, 0, 500);
		myScript.ChangeSpringJointSpring(myScript.springjointSpring);
		myScript.springjointDamper = EditorGUILayout.Slider ("Damper", myScript.springjointDamper, 0, 500);
		myScript.ChangeSpringJointDamper(myScript.springjointDamper);
		myScript.springjointMaxDistance = EditorGUILayout.Slider ("Max Distance", myScript.springjointMaxDistance, 0, 100);
		myScript.ChangeSpringJointMaxDistance(myScript.springjointMaxDistance);


		DrawDefaultInspector();
	}



}