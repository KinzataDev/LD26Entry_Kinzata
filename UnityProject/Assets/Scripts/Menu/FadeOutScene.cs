using UnityEngine;
using System.Collections;

public class FadeOutScene : MonoBehaviour {
	
	public float fadeInTime = 4;
	private float currentFadeInTime = 0;
	
	private bool fadeOut = false;
	private string levelToLoad;
	
	// Use this for initialization
	void Start () {
		Color col = guiTexture.color;
		col.a = 0;
		guiTexture.color = col;
	}
	
	// Update is called once per frame
	void Update () {
		
		if( fadeOut )
		{
			if( currentFadeInTime <= fadeInTime )
			{
				currentFadeInTime += Time.deltaTime;
				Color col = guiTexture.color;
				col.a = currentFadeInTime / fadeInTime;
				guiTexture.color = col;
				
				if( col.a >= 1)
				{
					Application.LoadLevel(levelToLoad);
				}
			}	
		}
	}
	
	public void FadeOut(string levelToLoad)
	{
		fadeOut = true;
		this.levelToLoad = levelToLoad;
	}
	
	
}
