using UnityEngine;
using System.Collections;

public class RetrieveHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "Your longest life was: " + PlayerPrefs.GetFloat(ScoreControl.LongestTimeString).ToString();
	}
}
