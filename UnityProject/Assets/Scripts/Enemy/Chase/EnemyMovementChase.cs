using UnityEngine;
using System.Collections;

public class EnemyMovementChase : MonoBehaviour {
	
	public float force;
	
	public float timeBetweenMoves = 5f;
	public float timeApplyForce = 5f;
	public float timeApplyAudio = 5f;
	
	private float moveTimer = 0;
	private float forceTimer = 0;
	private float audioTimer = 0;
	
	private Vector3 newForce = Vector3.zero;
	private Vector3 currentForce;
	
	private bool canMove = true;
	private bool shouldPlayAudio = true;
	
	public bool isChasingPlayer = false;
	public bool isPlayerControlled = false;
	
	public float forceNeeded;
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		newForce = Vector3.zero;
		
		if( canMove )
		{
			if( isPlayerControlled )
			{
				if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				{
					moveUp();
				}
				
				if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				{
					moveLeft();
				}
				
				if( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				{
					moveDown();
				}
				
				if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				{
					moveRight();
				}	
			}
			
			currentForce = newForce;
			
			gameObject.rigidbody.AddForce(newForce.normalized*force);
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
				gameObject.rigidbody.constraints = RigidbodyConstraints.None;
				canMove = true;
				moveTimer = 0;
				forceTimer = 0;
			}
		}
		
		if(!shouldPlayAudio)
		{
			audioTimer += Time.deltaTime;
			if( audioTimer >= timeApplyAudio)
			{
				audioTimer = 0;
				shouldPlayAudio = true;
			}
		}
		
	}
	
	void OnCollisionEnter( Collision obj )
	{
		if( shouldPlayAudio )
		{
			if( obj.impactForceSum.y > forceNeeded )
			{
				gameObject.audio.PlayOneShot(audio.clip);
				shouldPlayAudio = false;
			}		
		}

	}
	
	void OnCollisionStay( Collision obj )
	{

		if( shouldPlayAudio )
		{
			if( obj.impactForceSum.y > forceNeeded )
			{
				gameObject.audio.PlayOneShot(audio.clip);
				shouldPlayAudio = false;
			}		
		}	

	}
	
	void MoveTowardPlayer(int direction)
	{
		if( canMove )
		{
			switch(direction)
			{
			case 6:
			{
				moveRight();
				break;
			}
			case 4:
			{
				moveLeft();
				break;
			}
			case 8:
			{
				moveUp();
				break;
			}
			case 2:
			{
				moveDown();
				break;
			}
			}
			
			currentForce = newForce;
			
			gameObject.rigidbody.AddForce(newForce.normalized*force);
		}
	}
	
	
	
	
	
	public void moveUp()
	{
		gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		newForce += new Vector3(0,0,force);
		canMove = false;
	}
	
	public void moveDown()
	{
		gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		newForce += new Vector3(0,0,-force);
		canMove = false;
	}
	
	public void moveLeft()
	{
		gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		newForce += new Vector3(-force,0,0);
		canMove = false;
	}
	
	public void moveRight()
	{
		gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		newForce += new Vector3(force,0,0);
		canMove = false;
	}
	
	
}
