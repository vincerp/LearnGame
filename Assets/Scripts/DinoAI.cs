using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour 
{
	public float idleTime = 3f;
	
	public float fightRange = 1f;
	public float attackForce = 100f;

	private float speed = 1f;

    private bool isHittin = false;

    private Transform player = null;

	void Start () 
	{
		StartCoroutine(WalkAround());

		speed = GetComponent<NodeFollower>().speed;

	}
	
	void OnTriggerEnter(Collider other)
	{
		if( other.gameObject.tag != "Player" )
			return;


        player = other.transform;

		StopAllCoroutines();
		GetComponent<NodeFollower>().StopAllCoroutines();
       
		animation.Play("Walk");

	}

    void OnTriggerExit(Collider other)
    {
        if( other.gameObject.tag != "Player" )
            return;

        player = null;

        animation.Play("Idle");

        StartCoroutine(WalkAround());
    }

	IEnumerator WalkAround()
	{
		while( true )
		{
			yield return new WaitForSeconds(idleTime);

			NodeFollower follower = GetComponent<NodeFollower>();

			if( !follower.isMoving )
				GetComponent<NodeFollower>().MoveToNext();
		}
	}

    void Update()
    {
        if( player == null )
            return;

        if( (transform.position - player.position).magnitude > fightRange )
		{
			if( !animation.isPlaying )
				animation.Play("Walk");

            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
			transform.LookAt( player);
		}
        else
        {
            if( !isHittin )
            {
                animation.Play("Attack");
				isHittin = true;
            }
        }
    }

    public void ApplyAttack()
    {
        if( player == null )
            return;

		player.GetComponent<CharacterController>().Move( (transform.forward + transform.up ) * attackForce );

		OnTriggerExit(player.collider);
    }
}
