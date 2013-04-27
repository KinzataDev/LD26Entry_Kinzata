using UnityEngine;
using System.Collections;

public class ChasePlayerAI : AI {
	
	public float maxDistanceToFollow = 10;
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.Find("Player");
		// Find vector towards player
		if( target != null )
		{
			Vector3 position = gameObject.transform.position;
			Vector3 targetPosition = target.transform.position;
			
			Vector3 toVector = targetPosition - position;
			toVector.y = 0;
			
			if( toVector.magnitude < maxDistanceToFollow )
			{
				toVector = toVector.normalized;
				FollowPlayer(toVector);
			}
			else
			{
				MoveRandom();
			}
		}
		else
		{
			MoveRandom();
		}
	}
	
	private void MoveRandom()
	{
		gameObject.GetComponent<EnemyMovementChase>().timeBetweenMoves = 3;
				
		int val = Random.Range(1,5);
		switch(val)
		{
		case 1:
			gameObject.SendMessage("MoveTowardPlayer", 6);
			break;
		case 2:
			gameObject.SendMessage("MoveTowardPlayer", 4);
			break;
		case 3:
			gameObject.SendMessage("MoveTowardPlayer", 8);
			break;
		case 4:
			gameObject.SendMessage("MoveTowardPlayer", 2);
			break;
		}
	}
	
	private void FollowPlayer(Vector3 toVector)
	{
		gameObject.GetComponent<EnemyMovementChase>().timeBetweenMoves = 1.5f;
		
		float x = toVector[0];
		float z = toVector[2];
		
		// Right or Left
		if( Mathf.Abs(x) > Mathf.Abs(z) )
		{
			// Right
			if( x > 0)
			{
				gameObject.SendMessage("MoveTowardPlayer", 6);
			}
			else
			{
				gameObject.SendMessage("MoveTowardPlayer", 4);
			}
		}
		// Up or Down
		else
		{
			// Up
			if( z > 0)
			{
				gameObject.SendMessage("MoveTowardPlayer", 8);
			}
			else
			{
				gameObject.SendMessage("MoveTowardPlayer", 2);
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Vector3 position = transform.position;
		
		Gizmos.DrawWireSphere(position, maxDistanceToFollow);
	}
}
