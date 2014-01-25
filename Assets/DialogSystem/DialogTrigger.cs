using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour 
{
	// Create a dialog using
	// Assets -> Create -> Dialog
	// in current folder an asset will appear
	// in which you can fill in messages and speakers
	// assign this asset to the following field on dialog trigger
	public Dialog dialog;

	public bool playOnce = true;
	public Transform cameraFocusOn = null;

	private bool played = false;
	
	void OnTriggerEnter( Collider other)
	{
		if( other.gameObject.tag != "Player" )
			return;

		if (DialogPlayer.Instance && DialogPlayer.Instance.dialogToPlay != null )
			return;

		if( playOnce && played)
			return;

		DialogPlayer.Instance.Play(dialog as Dialog);

		if( cameraFocusOn != null )
		{
//			Camera.main.transform.LookAt(cameraFocusOn);

			// maybe if there MouseOrbit, we could attach it too
		}

		played = true;
	}

	void OnDrawGizmos(){
		Gizmos.color = new Color(0.1f, 0.2f, 0.8f, 0.5f);

		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawCube(Vector3.zero, (collider as BoxCollider).size);
	
	}
}
