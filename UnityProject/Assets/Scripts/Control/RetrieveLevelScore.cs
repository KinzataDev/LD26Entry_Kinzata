using UnityEngine;
using System.Collections;

public class RetrieveLevelScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "The furthest you've gone was level " + PlayerPrefs.GetInt(ScoreControl.HighestLevelString).ToString();
	}
}
