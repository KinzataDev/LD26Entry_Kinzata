using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {
	
	private static float time = 0;
	
	private static bool timing = true;
	private static string HighScoreString = "KinzataHighScore";
	
	// Use this for initialization
	void Start () {
		ScoreControl.timing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if( ScoreControl.timing )
		{
			ScoreControl.time += Time.deltaTime;
		}
		
		
		guiText.text = ScoreControl.time.ToString("0.000");
	}
	
	public static void StopTimer()
	{
		timing = false;
	}
	
	public static void StartTimer()
	{
		timing = true;
	}
	
	public static void ResetTime()
	{
		ScoreControl.time = 0;
	}
	
	public static void EnterScore()
	{
		if( PlayerPrefs.GetFloat(HighScoreString) < ScoreControl.time )
		{
			PlayerPrefs.SetFloat(HighScoreString, ScoreControl.time);
		}
		
	}
	
}
