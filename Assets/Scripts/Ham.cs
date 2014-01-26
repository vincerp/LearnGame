using UnityEngine;
using System.Collections;

public class Ham : MonoBehaviour {

	public static bool aquired = false;

	void OnTriggerEnter (Collider col) {
		if(col.tag != "Player") return;

		print("Ham aquired");
		aquired = true;
		GameGUI.instance.ActivateHam();
		Destroy(gameObject);
	}

	void FixedUpdate(){
		if(rigidbody.velocity.magnitude <= 0.1f && !collider.isTrigger){
			rigidbody.velocity = Vector3.zero;
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			collider.isTrigger = true;
			(collider as BoxCollider).size *= 2f;
		}
	}
}
