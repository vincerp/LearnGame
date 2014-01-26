using UnityEngine;
using System.Collections;

public class AudioMono : MonoBehaviour {

	private static AudioSource _i;
	public static AudioSource instance{
		get{
			return _i;
		}
	}

	void Start(){
		_i = audio;
	}
}
