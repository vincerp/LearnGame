using UnityEngine;
using System.Collections;

public class FlyingEgg : MonoBehaviour {

	public Vector3 target = Vector3.zero;
	public Vector3 rotation = new Vector3(10f, 10f, 90f);
	public float speed = 0.5f;
	private Transform _tr;

	void Start(){
		_tr = transform;
	}

	void Update () {
		if(target == Vector3.zero) return;
		_tr.position = Vector3.MoveTowards(_tr.position, target, speed);
		_tr.Rotate(rotation);
		if(_tr.position == target) Destroy(gameObject);
	}

	public void SetTarget(Vector3 tg){
		target = tg;
	}
}
