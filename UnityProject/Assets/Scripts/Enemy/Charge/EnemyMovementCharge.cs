using UnityEngine;
using System.Collections;

public class EnemyMovementCharge : MonoBehaviour {
	
	public float force;
	
	public AudioClip groundHitSound;
	public AudioClip warningSound;
	
	public float timeBetweenMoves = 5f;
	public float timeApplyForce = 5f;
	public float timeApplyAudio = 5f;
	
	private float moveTimer = 0;
	private float forceTimer = 0;
	
	private Vector3 newForce = Vector3.zero;
	private Vector3 currentForce;
	
	private bool canMove = true;
	
	public float forceNeeded;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		newForce = Vector3.zero;
		
		if( canMove )
		{	
			currentForce = newForce;
			
			gameObject.rigidbody.AddForce(currentForce.normalized*force);
		}
		else if( forceTimer < timeApplyForce )
		{
			forceTimer += Time.deltaTime;
			gameObject.rigidbody.AddForce(currentForce.normalized*force);
		}
		else
		{
			moveTimer += Time.deltaTime;
			
			if( moveTimer >= timeBetweenMoves )
			{
				canMove = true;
				moveTimer = 0;
				forceTimer = 0;
			}
		}
	}
	
	void OnCollisionEnter( Collision obj )
	{

		if( obj.impactForceSum.y > forceNeeded )
		{
			gameObject.audio.PlayOneShot(groundHitSound);
		}	

	}
	
	void OnCollisionStay( Collision obj )
	{

		if( obj.impactForceSum.y > forceNeeded )
		{
			gameObject.audio.PlayOneShot(groundHitSound);
		}	

	}
	
	void ChargePlayer(Vector3 direction)
	{
		if( canMove )
		{
			gameObject.audio.PlayOneShot(warningSound);
			newForce += direction;
			canMove = false;
			
			currentForce = newForce;
			
			gameObject.rigidbody.AddForce(newForce.normalized*force);
		}
		else
		{
			newForce += direction;
			currentForce = newForce;
		}
		
		
	}
}
