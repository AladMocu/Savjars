using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor (typeof(Button))]
public class ButtonEditor : Editor {

	public SerializedProperty 
	action_prop,
	animator_prop,
	toChange_prop,
	requiredMass_prop,
	id_prop;

	void OnEnable()
	{
		requiredMass_prop= serializedObject.FindProperty ("requiredMass");
		action_prop = serializedObject.FindProperty ("action");
		animator_prop=serializedObject.FindProperty ("animator");
		id_prop=serializedObject.FindProperty ("id");
		toChange_prop = serializedObject.FindProperty ("toChange");

	}
	override public void OnInspectorGUI(){
		serializedObject.Update ();


		EditorGUILayout.PropertyField(requiredMass_prop,new GUIContent("requiredMass"));

		EditorGUILayout.PropertyField (action_prop);
		Button.Action ac = (Button.Action)action_prop.enumValueIndex;

	
		switch (ac) {

		case Button.Action.Animation:
			EditorGUILayout.PropertyField (animator_prop);
			break;

		case Button.Action.Bool:
			EditorGUILayout.PropertyField (id_prop);
			Button.Identifier id = (Button.Identifier)id_prop.enumValueIndex;
			EditorGUILayout.PropertyField(toChange_prop,new GUIContent("toChange"));
			break;
		}
		serializedObject.ApplyModifiedProperties ();
	}

}
