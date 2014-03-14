using UnityEngine;
using UnityEditor;
using System.Collections;

public class AudioAssetsUtils {

	[MenuItem("Assets/Audio/Set Audio Files as 2D")]
	public static void SetAudioFilesAs2D(){
		Debug.Log(Selection.activeObject.GetType());
		Object[] audios = Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets);

		int amount = 0;
		foreach(AudioClip a in audios){
			string path = AssetDatabase.GetAssetPath(a);
			AudioImporter ai = AudioImporter.GetAtPath(path) as AudioImporter;

			if(ai.threeD){
				ai.threeD = false;
				amount++;
				AssetDatabase.ImportAsset(path);
			}
		}

		Debug.Log(""+amount+" AudioClips converted to 2D.");
	}
	
	[MenuItem("Assets/Audio/Set Audio Files as 3D")]
	public static void SetAudioFilesAs3D(){
		Debug.Log(Selection.activeObject.GetType());
		Object[] audios = Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets);
		
		int amount = 0;
		foreach(AudioClip a in audios){
			string path = AssetDatabase.GetAssetPath(a);
			AudioImporter ai = AudioImporter.GetAtPath(path) as AudioImporter;
			
			if(!ai.threeD){
				ai.threeD = true;
				amount++;
				AssetDatabase.ImportAsset(path);
			}
		}
		
		Debug.Log(""+amount+" AudioClips converted to 3D.");
	}
	
	[MenuItem("Assets/Audio/Set Audio Files Format to Compressed")]
	public static void SetAudioFilesAsCompressed(){
		Debug.Log(Selection.activeObject.GetType());
		Object[] audios = Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets);
		
		int amount = 0;
		foreach(AudioClip a in audios){
			string path = AssetDatabase.GetAssetPath(a);
			AudioImporter ai = AudioImporter.GetAtPath(path) as AudioImporter;
			
			if(ai.format == AudioImporterFormat.Native){
				ai.format = AudioImporterFormat.Compressed;
				amount++;
				AssetDatabase.ImportAsset(path);
			}
		}
		
		Debug.Log(""+amount+" AudioClips' format changed to compressed.");
	}
	
	[MenuItem("Assets/Audio/Set Audio Files Format to Native")]
	public static void SetAudioFilesAsNative(){
		Debug.Log(Selection.activeObject.GetType());
		Object[] audios = Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets);
		
		int amount = 0;
		foreach(AudioClip a in audios){
			string path = AssetDatabase.GetAssetPath(a);
			AudioImporter ai = AudioImporter.GetAtPath(path) as AudioImporter;
			
			if(ai.format == AudioImporterFormat.Compressed){
				ai.format = AudioImporterFormat.Native;
				amount++;
				AssetDatabase.ImportAsset(path);
			}
		}
		
		Debug.Log(""+amount+" AudioClips' format changed to native.");
	}
}
