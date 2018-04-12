using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor (typeof(Accioner))]
public class ActionerEditor : Editor {

	public SerializedProperty 
	action_prop,
	animator_prop,
	toChange_prop,
	requiredMass_prop,
	id_prop,
	kind_prop,
	mode_prop;


	void OnEnable()
	{
		requiredMass_prop= serializedObject.FindProperty ("requiredMass");
		action_prop = serializedObject.FindProperty ("action");
		animator_prop=serializedObject.FindProperty ("animator");
		id_prop=serializedObject.FindProperty ("id");
		toChange_prop = serializedObject.FindProperty ("toChange");
		kind_prop = serializedObject.FindProperty ("kind");
		mode_prop = serializedObject.FindProperty ("mode");

	}
	override public void OnInspectorGUI(){
		serializedObject.Update ();



		EditorGUILayout.PropertyField (kind_prop);
		Accioner.Kind k = (Accioner.Kind)kind_prop.enumValueIndex;

		if(k==Accioner.Kind.Button)
		{
			EditorGUILayout.PropertyField(requiredMass_prop,new GUIContent("requiredMass"));
		}




		EditorGUILayout.PropertyField (action_prop);
		Accioner.Action ac = (Accioner.Action)action_prop.enumValueIndex;


		switch (ac) {

		case Accioner.Action.Animation:
			EditorGUILayout.PropertyField (animator_prop);
			EditorGUILayout.PropertyField (mode_prop);
			Accioner.Mode m = (Accioner.Mode)mode_prop.enumValueIndex;
			break;

		case Accioner.Action.Bool:
			EditorGUILayout.PropertyField (id_prop);
			Accioner.Identifier id = (Accioner.Identifier)id_prop.enumValueIndex;
			EditorGUILayout.PropertyField(toChange_prop,new GUIContent("toChange"));
			break;
		}
		serializedObject.ApplyModifiedProperties ();
	}

}
