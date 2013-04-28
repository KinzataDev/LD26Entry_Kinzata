using UnityEngine;
using System.Collections;

public class OnCollisionWithEnemy : MonoBehaviour {
	
	public bool canDie = true;
	
	void OnCollisionEnter(Collision hit)
	{
		if( canDie )
		{
			if( hit.gameObject.tag == "Enemy")
			{
				ScoreControl.StopTimer();
				
				foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
				{
					enemy.GetComponent<AI>().enabled = false;
				}
				
				GameObject.Find("GameControl").SendMessage("EndGameByDeath");
				
				ScoreControl.EnterScore();
				
				GameObject.Find("Ground").AddComponent<AudioListener>();
				Destroy (gameObject);
			}	
		}
	}
	
}
