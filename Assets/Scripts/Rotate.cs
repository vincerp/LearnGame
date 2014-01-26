using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public Vector3 rotation;
	Transform _tr;

	// Use this for initialization
	void Start () {
		_tr = transform;
	}
	
	// Update is called once per frame
	void Update () {
		_tr.Rotate(rotation*Time.deltaTime);
	}
}
