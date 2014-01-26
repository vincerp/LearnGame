using UnityEngine;
using System.Collections;

public class TourGuideDialogEvents : MonoBehaviour 
{

	public void OnStartDialog()
	{

	}

	public void OnShowMessage()
	{
		int random = Random.Range(1,3);
		animation.Play("Talk" + random);
	}

	public void OnFinishDialog()
	{
		if(GetComponent<NodeFollower>())GetComponent<NodeFollower>().MoveToNext();
	}
}
