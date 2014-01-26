using UnityEngine;
using System.Collections;

public class DialogPlayer : MonoBehaviour {

	public static DialogPlayer mInstance = null;
	public static DialogPlayer Instance
	{
		get { return mInstance; }
		set { mInstance = value; }
	}

	TextMesh mesh;
	public Dialog dialogToPlay = null;
	int messageIndex = 0;

	MeshRenderer[] renderers;

	void Awake()
	{
		mesh = GetComponentInChildren<TextMesh>();
		Instance = this;

		transform.parent.camera.enabled = false;
	}

	void Update()
	{
		if( Input.GetMouseButtonUp(0) )
		{ 
			Ray ray = transform.parent.camera.ScreenPointToRay( Input.mousePosition );

			if( Physics.Raycast( ray, Mathf.Infinity, 1 << gameObject.layer ) )
			{
				if( dialogToPlay == null )
					return;

				if( dialogToPlay.messages.Count > messageIndex )
					ShowMessage( dialogToPlay.messages[messageIndex] );
				else
				{
					dialogToPlay = null;
					messageIndex = 0;

					transform.parent.camera.enabled = false;

					GameObject.FindWithTag("TourGuide").GetComponent<NodeFollower>().MoveToNext();
				}

			}
		}
	}

	public void Play( Dialog dialog )
	{
		dialogToPlay = dialog;

		transform.parent.camera.enabled = true;

		if( dialog.messages.Count > 0 )
			ShowMessage( dialog.messages[messageIndex] );
	}

	public void ShowMessage( Message message )
	{
		mesh.text = message.speaker + ": \n\n" + message.message;
		messageIndex++;

		// rooting to "Tour Guide" object
		int random = Random.Range(1,3);
		transform.parent.parent.parent.animation.Play("Talk" + random);
	}
}
