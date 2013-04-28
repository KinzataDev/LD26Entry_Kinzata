using UnityEngine;
using System.Collections;

public class Expander : AI {
	
	public int maxAttempts = 10;
	public float timeBetweenExpands = 3;
	private float timeToExpand;
	
	public int numSameExpands = 4;
	private int numCurrentExpands = 0;
	private bool shouldChangeDirection = true;
	
	private Vector3 vecToTransform = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		numCurrentExpands = numSameExpands + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		timeToExpand += Time.deltaTime;
		
		if( timeToExpand >= timeBetweenExpands )
		{
			timeToExpand = 0;
			Expand();
		}
	}
	
	void Expand()
	{
		bool hasExpanded = false;
		int numAttempts = 0;
		
		while( !hasExpanded && numAttempts < maxAttempts)
		{
			// Move in cardinal direction
			if( shouldChangeDirection )
			{
				int val = Random.Range(1,5);
				switch(val)
				{
				case 1:
					// Up
					vecToTransform = new Vector3(0,0,1);
					break;
				case 2:
					// Down
					vecToTransform = new Vector3(0,0,-1);
					break;
				case 3:
					// Left
					vecToTransform = new Vector3(-1,0,0);
					break;
				case 4:
					// Right
					vecToTransform = new Vector3(1,0,0);
					break;
				}	
			}
			
			Vector3 curPosition = transform.position;
			
			if( !Physics.Raycast(new Ray(curPosition,vecToTransform),1) )
			{
				// Duplicate
				GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
				clone.name = gameObject.name;
				clone.GetComponent<Expander>().enabled = false;
				transform.position = curPosition + vecToTransform;
				
				hasExpanded = true;
				numCurrentExpands++;
				shouldChangeDirection = false;
				
				if( numCurrentExpands >= numSameExpands )
				{
					numCurrentExpands = 0;
					shouldChangeDirection = true;
					numSameExpands = Random.Range(3, 7);
				}
			}	
			
			numAttempts++;
		}
		
		if( numAttempts >= maxAttempts )
		{
			shouldChangeDirection = true;
		}
	}
}
