using UnityEngine;
using System.Collections;

public class Caldron : MonoBehaviour {
	
	private float lastTimeEggPulled = 0f;
	public float timeBetweenEggs = 1f;
	public GameObject egg;
	public float speed;

	public Vector3 moveTo;

	public int eggsPulled = 0;
	public int eggsTotal = 20;

	void OnTriggerStay (Collider col) {
		if(col.tag != "Player") return;

		if(Time.time <= lastTimeEggPulled+timeBetweenEggs || Collectable.collected <= 0) return;
		GameObject newEgg = Instantiate(egg) as GameObject;
		newEgg.SendMessage("SetTarget", transform.position+moveTo);
		newEgg.transform.position = col.transform.position;
		Collectable.collected--;
		eggsPulled++;
		lastTimeEggPulled = Time.time;
		if(eggsPulled>= eggsTotal){
			//TODO: something!
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position+moveTo, 0.5f);
	}
}
