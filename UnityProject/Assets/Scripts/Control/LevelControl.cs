using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	
	public GameObject goal;
	
	public int currentLevel = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void GoalFound()
	{
		GameObject.FindWithTag("Player").GetComponent<OnCollisionWithEnemy>().enabled = false;
		GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enabled = false;
		StartCoroutine(ClearEnemies());
		StartCoroutine (BeginNextLevel());
	}
	
	public void SpawnGoal()
	{
		GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().Spawn(goal);
	}
	
	private IEnumerator BeginNextLevel()
	{
		yield return new WaitForSeconds(3);
		currentLevel++;
		ScoreControl.ResetTime();
		GameObject.FindWithTag("Player").GetComponent<OnCollisionWithEnemy>().enabled = true;
		GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enabled = true;
	}
	
	public void EndGameByDeath()
	{
		StartCoroutine(privateEndGameByDeath());
	}
	
	private IEnumerator ClearEnemies()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			yield return new WaitForSeconds(0.005f);
			Destroy (obj);
		}
		
		// In case anything spawns during the above loop
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			yield return new WaitForSeconds(0.01f);
			Destroy (obj);
		}
	}
	
	private IEnumerator privateEndGameByDeath()
	{
		GameObject.Find("GameOverPopup").GetComponent<GUIText>().enabled = true;
		yield return new WaitForSeconds(3);
		
		ScoreControl.ResetTime();
		PowerLimit.Reset();
		Application.LoadLevel("MenuScene");
	}
}
