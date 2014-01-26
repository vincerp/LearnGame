using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NodeFollower : MonoBehaviour {

	public Transform pathObj;

	public System.Action MoveToNext;

	public List<Transform> nodeList;
	protected int currentNode = 0;

	public float speed = 1f;
	public bool isCircle = false;

	private Transform _tr;

	private void Start(){
		_tr = transform;

		MoveToNext += MoveToNextHandler;
	}

	protected void MoveToNextHandler(){
		currentNode++;
		if(nodeList.Count > currentNode){
			StartCoroutine("Move");
		} else {
			if(isCircle){
				currentNode = 0;
				StartCoroutine("Move");
			} else {
				Debug.LogError("Node number " + currentNode + " does not exist!");
			}
		}
	}

	protected IEnumerator Move(){
		Transform cNode = nodeList[currentNode];

		transform.LookAt(cNode);
		//start walking
		while(_tr.position != cNode.position){
			_tr.position = Vector3.MoveTowards(_tr.position, cNode.position, speed);

			yield return true;
		}
		//stop walking
		if(cNode.name.Contains("_")) MoveToNext();
	}

#if UNITY_EDITOR
	[ContextMenu("Add Node")]
	private void AddNode(){
		Transform newTransf = new GameObject().transform;
		newTransf.parent = pathObj;
		newTransf.localPosition = Vector3.zero;
		nodeList.Add(newTransf);
		newTransf.name = "Node " + nodeList.Count;
	}

	private void OnDrawGizmos(){
		if(null == nodeList) return;
		int c = nodeList.Count;
		if(c<1) return;

		for(int i = 0; i < c; i++){
			if(nodeList[i] == null) break;
			Gizmos.color = (nodeList[i].name.Contains("_"))?Color.yellow:Color.red;
			Gizmos.DrawSphere(nodeList[i].position, 0.9f);
			if(i==0){
				if(isCircle){
					Gizmos.DrawLine(nodeList[i].position, nodeList[nodeList.Count-1].position);
					continue;
				} else continue;
			}
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(nodeList[i].position, nodeList[i-1].position);
		}
	}
#endif
}
