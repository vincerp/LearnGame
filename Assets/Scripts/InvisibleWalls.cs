using UnityEngine;
using System.Collections;

public class InvisibleWalls : MonoBehaviour {

#if UNITY_EDITOR
	[ContextMenu("Kill Renderers")]
	void KillRenderers () {
		foreach(Transform child in transform){
			DestroyImmediate(child.renderer);
		}
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(0.4f, 1f, 0.8f, 0.6f);
		foreach(Transform child in transform){
			Gizmos.matrix = child.localToWorldMatrix;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.color = new Color(0.2f, 1f, 0.5f, 0.3f);
		foreach(Transform child in transform){
			Gizmos.matrix = child.localToWorldMatrix;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}
	}
#endif
}
