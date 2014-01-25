using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	
	public Transform target;
	public Vector3 rotationOffset;
	public Transform player;
	public Vector3 playerOffset;
	public float followSpeed = 1f;

	void Update(){
		if(!target) return;
		transform.LookAt(target.position);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationOffset);
		transform.position = Vector3.MoveTowards(transform.position, player.position+playerOffset, followSpeed);
	}
}
