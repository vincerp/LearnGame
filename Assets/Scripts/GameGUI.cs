using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public static GameGUI instance;

	public GUISkin skin;
	public int totalEggs = 20;
	public Rect eggsPos;
	private Rect _eggsPos;
	
	public GameObject egg;
	public GameObject ham;

	void Start(){
		instance = this;
	}

	public void ActivateHam(){
		egg.SetActive(false);
		ham.SetActive(true);
	}

	void OnGUI(){
		if(skin)GUI.skin = skin;
		_eggsPos = eggsPos;
		GUI.color = Color.black;
		GUI.Label(_eggsPos, ""+Collectable.collected+"/"+totalEggs);
		_eggsPos.x-=1f;
		_eggsPos.y-=1f;
		GUI.color = Color.white;
		GUI.Label(_eggsPos, ""+Collectable.collected+"/"+totalEggs);
	}
}
