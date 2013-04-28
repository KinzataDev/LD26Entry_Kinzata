using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	public float fadeInTime = 4;
	private float currentFadeInTime = 0;
	
	void Start()
	{
		Color col = GUI.color;
		col.a = 0;
		GUI.color = col;
	}
	
	void Update()
	{
		if( Input.GetKeyDown(KeyCode.Space) )
		{
			Application.LoadLevel("MainScene");
		}
		
		
	}
	
	void OnGUI()
	{
		if( currentFadeInTime <= fadeInTime )
		{
			currentFadeInTime += Time.deltaTime;
			Color col = GUI.color;
			col.a = currentFadeInTime / fadeInTime;
			GUI.color = col;
		}
		
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		if( GUILayout.Button("Survive"))
		{
			Application.LoadLevel("MainScene");
		}
		
		GUILayout.EndArea();
	}
}
