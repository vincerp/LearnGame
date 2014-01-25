using UnityEngine;
using System.Collections;

public class InvisibleWalls : MonoBehaviour {

	void Start () {
		foreach(Transform child in transform){
			Destroy(child.renderer);
		}
	}
}
