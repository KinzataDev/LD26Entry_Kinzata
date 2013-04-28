using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	void OnTriggerEnter( Collider hit )
	{
		GameObject.Find("GameControl").GetComponent<LevelControl>().GoalFound();
		Destroy(gameObject);
	}
}
