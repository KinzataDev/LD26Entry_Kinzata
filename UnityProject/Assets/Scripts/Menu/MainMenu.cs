using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f)) ;//- (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		if( GUILayout.Button("Survive"))
		{
			Application.LoadLevel("MainScene");
		}
		
		GUILayout.EndArea();
	}
}
