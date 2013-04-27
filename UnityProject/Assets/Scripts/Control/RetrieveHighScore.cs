using UnityEngine;
using System.Collections;

public class RetrieveHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "Your current HighScore is: " + PlayerPrefs.GetFloat("KinzataHighScore").ToString();
	}
}
