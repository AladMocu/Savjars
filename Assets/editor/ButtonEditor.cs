using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Button))]
public class ButtonEditor : Editor {

	public SerializedProperty 
	action_prop,
	animator_prop,
	id_prop;

	void OnEnable()
	{
		action_prop = serializedObject.FindProperty ("action");
		animator_prop=serializedObject.FindProperty ("animator");
		id_prop=serializedObject.FindProperty ("id");

	}
	override public void OnInspectorGUI(){
		serializedObject.Update ();
		EditorGUILayout.PropertyField (action_prop);
		Button.Action ac = (Button.Action)action_prop.enumValueIndex;


	
		switch (ac) {

		case Button.Action.Animation:
			EditorGUILayout.PropertyField (animator_prop);
			break;

		case Button.Action.Bool:
			EditorGUILayout.PropertyField (id_prop);
			Button.Identifier id = (Button.Identifier)id_prop.enumValueIndex;

			break;
		}
	}

}
