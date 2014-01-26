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

	Transform cameraFocus = null;

	void Awake()
	{
		mesh = GetComponentInChildren<TextMesh>();
		Instance = this;

		GameObject.FindWithTag("HUDCamera").camera.enabled = false;
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

					GameObject.FindWithTag("HUDCamera").camera.enabled = false;

					if( cameraFocus != null )
						cameraFocus.SendMessage("OnFinishDialog", SendMessageOptions.DontRequireReceiver);
				}

			}
		}
	}

	public void Play( Dialog dialog, Transform focus = null )
	{
		dialogToPlay = dialog;
		cameraFocus = focus;

		if( dialog.messages.Count > 0 )
			ShowMessage( dialog.messages[messageIndex] );

		Transform cameraPivot = null;
		if( cameraFocus != null )
		{
			cameraPivot = focus.FindChild("CameraFocus");
			cameraFocus.SendMessage("OnStartDialog", SendMessageOptions.DontRequireReceiver);
		}

		Transform dialogCam = GameObject.FindWithTag("HUDCamera").transform;
		dialogCam.transform.parent = cameraPivot;	// may be null

		dialogCam.localPosition = Vector3.zero;
		dialogCam.localRotation = Quaternion.identity;
		dialogCam.Rotate(dialogCam.up, 180f);

		dialogCam.camera.enabled = true;
	}

	public void ShowMessage( Message message )
	{
		mesh.text = message.speaker + ": \n\n" + message.message;
		messageIndex++;

		if( cameraFocus != null )
			cameraFocus.SendMessage("OnShowMessage", SendMessageOptions.DontRequireReceiver);
	}
}
