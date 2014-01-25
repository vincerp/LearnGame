using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public GUISkin skin;
	public int totalEggs = 20;
	public Rect eggsPos;

	void OnGUI(){
		if(skin)GUI.skin = skin;
		GUI.Label(eggsPos, ""+Collectable.collected+"/"+totalEggs);
	}
}
