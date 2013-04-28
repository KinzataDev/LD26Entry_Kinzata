using UnityEngine;
using System.Collections;

public class FadeInScene : MonoBehaviour {
	
	public float fadeInTime = 4;
	private float currentFadeInTime = 0;
	
	// Use this for initialization
	void Start () {
		currentFadeInTime = 2;
		Color col = guiTexture.color;
		col.a = 1;
		guiTexture.color = col;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if( currentFadeInTime >= 0 )
		{
			currentFadeInTime -= Time.deltaTime;
			Color col = guiTexture.color;
			col.a = currentFadeInTime / fadeInTime;
			guiTexture.color = col;
		}
		
	}
	
	
}
