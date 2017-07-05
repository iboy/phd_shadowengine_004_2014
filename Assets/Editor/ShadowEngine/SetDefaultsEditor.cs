using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SetDefaults))]
public class SetDefaultsEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
	}
}