using UnityEngine;
using System.Collections;

public class RetrieveHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "Your longest time was: " + PlayerPrefs.GetFloat(ScoreControl.LongestTimeString).ToString();
	}
}
