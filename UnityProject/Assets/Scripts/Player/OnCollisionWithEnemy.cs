using UnityEngine;
using System.Collections;

public class OnCollisionWithEnemy : MonoBehaviour {
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.tag == "Enemy")
		{
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				enemy.GetComponent<AI>().enabled = false;
			}
			
			GameObject.Find("GameControl").SendMessage("EndGameByDeath");
			
			Destroy (gameObject);
			GameObject.Find("Ground").AddComponent<AudioListener>();
		}
	}
	
}
