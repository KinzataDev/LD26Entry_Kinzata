using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {
	
	public GameObject CubeForm;
	
	public float force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newForce = Vector3.zero;
		
		if( Input.GetKey(KeyCode.W) )
		{
			newForce += new Vector3(0,0,force);
		}
		
		if( Input.GetKey(KeyCode.A) )
		{
			newForce += new Vector3(-force,0,0);
		}
		
		if( Input.GetKey(KeyCode.S) )
		{
			newForce += new Vector3(0,0,-force);
		}
		
		if( Input.GetKey(KeyCode.D) )
		{
			newForce += new Vector3(force,0,0);
		}
		
		gameObject.rigidbody.AddForce(newForce.normalized*force);
	}
}
