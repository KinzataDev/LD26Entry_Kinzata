using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {
	
	private static float totalTime = 0;
	private static float levelTime = 45;
	
	private static bool timing = true;
	public static string LongestTimeString = "YouDontBelongHere_Time";
	public static string HighestLevelString = "YouDontBelongHere_Level";
	
	// Use this for initialization
	void Start () {
		ScoreControl.timing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if( ScoreControl.timing )
		{
			ScoreControl.levelTime -= Time.deltaTime;
			ScoreControl.totalTime += Time.deltaTime;
		}
		
		if( ScoreControl.levelTime < 0 )
		{
			ScoreControl.totalTime += Time.deltaTime;
			GameObject.Find("GameControl").GetComponent<LevelControl>().SpawnGoal();
			ScoreControl.levelTime = 0;
			ScoreControl.timing = false;
		}
		
		guiText.text = ScoreControl.levelTime.ToString("0.000");
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
		levelTime = 45;
		timing = true;
	}
	
	public static void EnterScore()
	{
		if( PlayerPrefs.GetFloat(LongestTimeString) < ScoreControl.totalTime )
		{
			PlayerPrefs.SetFloat(LongestTimeString, ScoreControl.totalTime);
		}
		
		LevelControl obj = GameObject.Find("GameControl").GetComponent<LevelControl>();
		
		if( PlayerPrefs.GetInt(HighestLevelString) < obj.currentLevel )
		{
			PlayerPrefs.SetInt(HighestLevelString, obj.currentLevel);
		}
		
	}
	
}
