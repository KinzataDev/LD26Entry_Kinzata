using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void EndGameByDeath()
	{
		StartCoroutine(privateEndGameByDeath());
	}
	
	private IEnumerator privateEndGameByDeath()
	{
		GameObject.Find("GameOverPopup").GetComponent<GUIText>().enabled = true;
		yield return new WaitForSeconds(3);
		
		ScoreControl.ResetTime();
		Application.LoadLevel("MenuScene");
	}
}
