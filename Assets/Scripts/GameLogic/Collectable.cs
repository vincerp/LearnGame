using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour {

	public static int collected = 0;

	public GameObject particles;
	public Vector3 rotateSpeed;

	public AudioClip sound;

	private Transform _tr;

	void Start(){
		_tr = transform;
	}

	void Update () {
		_tr.Rotate(rotateSpeed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if(col.tag != "Player") return;

		collected++;

		GameObject p = Instantiate(particles) as GameObject;
		p.transform.position = _tr.position;
		AudioMono.instance.PlayOneShot(sound);
		GameObject.Destroy(p, 2f);
		Destroy(gameObject);
	}
}
