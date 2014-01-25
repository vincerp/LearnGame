using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dialog))]
public class DialogEditor : Editor 
{

	public override void OnInspectorGUI() 
	{
		serializedObject.Update();

		SerializedProperty tps = serializedObject.FindProperty ("messages");
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.PropertyField(tps, true);
		if(EditorGUI.EndChangeCheck())
			serializedObject.ApplyModifiedProperties();
		EditorGUIUtility.LookLikeControls();

	}
}