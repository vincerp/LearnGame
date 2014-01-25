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

		renderers = GetComponentsInChildren<MeshRenderer>();

		foreach( Renderer renderer in renderers)
			renderer.enabled = false;
	}

	void Update()
	{
		if( Input.GetMouseButtonUp(0) )
		{ 
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

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

					foreach( Renderer renderer in renderers)
						renderer.enabled = false;
				}

			}
		}
	}

	public void Play( Dialog dialog )
	{
		dialogToPlay = dialog;

		foreach( Renderer renderer in renderers)
			renderer.enabled = true;

		if( dialog.messages.Count > 0 )
			ShowMessage( dialog.messages[messageIndex] );
	}

	public void ShowMessage( Message message )
	{
		mesh.text = message.speaker + ": \n\n" + message.message;
		messageIndex++;
	}
}
