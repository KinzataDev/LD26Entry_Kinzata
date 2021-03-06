using UnityEngine;
using System.Collections;

public class ChasePlayerAIYellow : AI {
	
	public float maxDistanceToFollow = 10;
	
	public bool movesAlongX = true;
	
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
		gameObject.GetComponent<EnemyMovementChaseYellow>().timeBetweenMoves = 3;
				
		if( movesAlongX )
		{
			int val = Random.Range(1, 3);
			switch(val)
			{
			case 1:
				gameObject.SendMessage("MoveTowardPlayer", 6);
				break;
			case 2:
				gameObject.SendMessage("MoveTowardPlayer", 4);
				break;
			}
		}
		else
		{
			int val = Random.Range(1, 3);
			switch(val)
			{
			case 1:
				gameObject.SendMessage("MoveTowardPlayer", 8);
				break;
			case 2:
				gameObject.SendMessage("MoveTowardPlayer", 2);
				break;
			}
		}
		
	}
	
	private void FollowPlayer(Vector3 toVector)
	{
		gameObject.GetComponent<EnemyMovementChaseYellow>().timeBetweenMoves = 1.5f;
		
		float x = toVector[0];
		float z = toVector[2];
		
		// Right or Left
		if( Mathf.Abs(x) > Mathf.Abs(z) )
		{
			// Right
			if( movesAlongX )
			{
				if( x > 0)
				{
					gameObject.SendMessage("MoveTowardPlayer", 6);
				}
				else
				{
					gameObject.SendMessage("MoveTowardPlayer", 4);
				}	
			}
			else
			{
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
		// Up or Down
		else
		{
			// Up
			if( !movesAlongX )
			{
				if( z > 0)
				{
					gameObject.SendMessage("MoveTowardPlayer", 8);
				}
				else
				{
					gameObject.SendMessage("MoveTowardPlayer", 2);
				}	
			}
			else
			{
				if( x > 0)
				{
					gameObject.SendMessage("MoveTowardPlayer", 6);
				}
				else
				{
					gameObject.SendMessage("MoveTowardPlayer", 4);
				}
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Vector3 position = transform.position;
		
		Gizmos.DrawWireSphere(position, maxDistanceToFollow);
	}
}
