using UnityEngine;
using System.Collections;

public class SwapForm : MonoBehaviour {
	
	public GameObject otherForm;
	
	public int maxUses = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Space) )
		{
			if( gameObject.name == "Player")
			{
				if( PowerLimit.numPowersUsed < maxUses )
				{
					PowerLimit.numPowersUsed++;
					GameObject obj = Instantiate(otherForm, transform.position, Quaternion.identity) as GameObject;
					obj.name = otherForm.name;
					ScoreControl.StopTimer();
					Destroy(gameObject);
				}
			}
			else
			{
				GameObject obj = Instantiate(otherForm, transform.position, Quaternion.identity) as GameObject;
				obj.name = otherForm.name;
				ScoreControl.StartTimer();
				Destroy(gameObject);
			}
			
		}
	}
}
