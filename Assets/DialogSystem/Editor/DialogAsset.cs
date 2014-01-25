using UnityEngine;
using UnityEditor;

public class DialogAsset
{
	[MenuItem("Assets/Create/Dialog")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<Dialog> ();
	}
}