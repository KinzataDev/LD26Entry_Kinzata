using UnityEngine;
using System.Collections;

public class ChargePlayerAI : AI {
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Find vector towards player
		target = GameObject.Find("Player");
		
		if( target != null )
		{
			Vector3 position = gameObject.transform.position;
			Vector3 targetPosition = target.transform.position;
			
			Vector3 toVector = targetPosition - position;
			
			toVector.y = 0;
			toVector = toVector.normalized;
			
			gameObject.SendMessage("ChargePlayer", toVector);
		}
	}
}
