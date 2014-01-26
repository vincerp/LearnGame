using UnityEngine;
using System.Collections;

public class AutoAnimate : MonoBehaviour {

	public AnimationClip clip;
	public WrapMode wrap = WrapMode.Loop;
	public float rotate = 0f;

	private Transform _tr;

	IEnumerator Start () {
		animation.clip = clip;
		animation.wrapMode = wrap;
		animation.Play();

		_tr = transform;

		yield return new WaitForEndOfFrame();
		NodeFollower nf = GetComponent<NodeFollower>();
		if(nf != null){
			nf.MoveToNext();
		}
	}

	void Update(){
		if(rotate > 1f) _tr.Rotate(Vector3.up, rotate);
	}
}
