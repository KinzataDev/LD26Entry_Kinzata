using UnityEngine;
using System.Collections;

public class PopupText : MonoBehaviour {

	public float fadeTime = 6;
	
	private float currentFadeTime = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		currentFadeTime += Time.deltaTime;
		
		float alphaScale = (fadeTime - currentFadeTime) / fadeTime;
		
		Color color = gameObject.guiText.material.color;
		color.a = alphaScale;
		gameObject.guiText.material.color = color;
		
		if( alphaScale <= 0 )
		{
			Destroy (gameObject);
		}
	}
}
