using UnityEngine;
using System.Collections;

public class ChasePlayerAI : MonoBehaviour {
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Find vector towards player
		Vector3 position = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		
		Vector3 toVector = targetPosition - position;
		
		toVector.y = 0;
		toVector = toVector.normalized;
		
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
}
