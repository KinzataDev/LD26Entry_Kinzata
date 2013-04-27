using UnityEngine;
using System.Collections;

public class OnCollisionWithEnemy : MonoBehaviour {
	
	public GameObject Enemy;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.name == "Enemy")
		{
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				enemy.GetComponent<ChasePlayerAI>().enabled = false;
			}
			
			GameObject.Find("GameControl").SendMessage("EndGameByDeath");
			
			Destroy (gameObject);
			GameObject.Find("Ground").AddComponent<AudioListener>();
		}
	}
	
}
