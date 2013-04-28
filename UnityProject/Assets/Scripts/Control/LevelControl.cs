using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	
	public GameObject goal;
	public GameObject popupText;
	
	public int currentLevel = 1;
	
	private Vector3 popupPosition;
	
	// Use this for initialization
	void Start () {
		GameObject scoreTimer = GameObject.Find("ScoreText");
		
		popupPosition = scoreTimer.transform.position;
		popupPosition.x += 0.03f;
		popupPosition.y -= 0.04f;
		GameObject newText = Instantiate(popupText, popupPosition, Quaternion.identity) as GameObject;
		newText.guiText.text = "Something's coming...";
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
		
		GameObject goalObj = GameObject.Find("Goal");
		Vector3 point = Camera.mainCamera.WorldToScreenPoint(goalObj.transform.position);
		Vector3 newPoint = Camera.mainCamera.ScreenToViewportPoint(point);
		newPoint.x += 0.05f;
		newPoint.y += 0.01f;
		GameObject newText = Instantiate(popupText, newPoint, Quaternion.identity) as GameObject;
		
		switch(currentLevel)
		{
		case 1:
			newText.guiText.text = "What is this?";
			break;
		case 2:
			newText.guiText.text = "It's back...";
			break;
		case 3:
			newText.guiText.text = "Maybe if I keep trying?";
			break;
		default:
			newText.guiText.text = "There it is again";
			break;
		}
	}
	
	private IEnumerator BeginNextLevel()
	{
		yield return new WaitForSeconds(3);
		currentLevel++;
		ScoreControl.ResetTime();
		GameObject.FindWithTag("Player").GetComponent<OnCollisionWithEnemy>().enabled = true;
		GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enabled = true;
		
		GameObject newText = Instantiate(popupText, popupPosition, Quaternion.identity) as GameObject;
		
		
		switch(currentLevel)
		{
		case 2:
			newText.guiText.text = "Whoa...";
			break;
		case 3:
			newText.guiText.text = "Am I getting anywhere?";
			break;
		default:
			newText.guiText.text = "I can do it. ( Level " + currentLevel + " )";
			break;
		}
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
		Application.LoadLevel("MenuScene");
	}
}
