using UnityEngine;
using System.Collections;

public class ChargeHitBlack : MonoBehaviour {
	
	public float minspeedNeeded = 12.5f;
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.name == "EnemyWall" && gameObject.rigidbody.velocity.magnitude > minspeedNeeded)
		{
			Destroy (hit.gameObject);
		}
	}
}
