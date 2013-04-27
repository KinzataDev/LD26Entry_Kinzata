using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public float force;
	
	public float timeBetweenMoves = 5f;
	public float timeApplyForce = 5f;
	
	private float moveTimer = 0;
	private float forceTimer = 0;
	
	private Vector3 newForce = Vector3.zero;
	private Vector3 currentForce;
	
	private bool canMove = true;
	
	public bool isChasingPlayer = false;
	
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		newForce = Vector3.zero;
		
		if( canMove )
		{
			if( Input.GetKey(KeyCode.W) )
			{
				moveUp();
			}
			
			if( Input.GetKey(KeyCode.A) )
			{
				moveLeft();
			}
			
			if( Input.GetKey(KeyCode.S) )
			{
				moveDown();
			}
			
			if( Input.GetKey(KeyCode.D) )
			{
				moveRight();
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
