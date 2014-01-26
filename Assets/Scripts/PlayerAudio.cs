using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour {
	
	public AudioClip jump;
	public AudioClip step;

	void Start(){
		audio.clip = step;
		audio.loop = true;
	}

	void DidJump () {
		AudioMono.instance.PlayOneShot(jump);
	}

	void Update(){
		if(IsMoving()) {
			if(!audio.isPlaying)audio.Play();
		} else {
			if(audio.isPlaying)audio.Pause();
		}
	}

	bool IsMoving(){
		return Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5;
	}
}
