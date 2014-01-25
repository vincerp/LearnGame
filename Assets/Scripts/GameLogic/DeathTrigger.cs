using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	private Transform player;
	private Vector3 startingPos;

	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		startingPos = player.position;
	}
	
	void OnTriggerEnter (Collider col) {
		if(col.tag == "Player"){
			player.position = startingPos;
		}
	}
}
