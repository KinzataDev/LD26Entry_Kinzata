using UnityEngine;
using System.Collections;

public class StoryBoardControl : MonoBehaviour {
	
	private GameObject currentGui;
	
	public float fadeInTime = 4;
	private float currentFadeInTime = 0;
	
	public float betweenTime = 2;
	private float currentBetweenTime = 0;
	
	private bool isFadingText = false;
	private bool isFadingIn = true;
	
	public string[] storyChunks;
	private int currentStoryIndex = 0;
	
	public GameObject[] textHolders;
	private int currentHolderIndex = 0;
	
	// Use this for initialization
	void Start () {
		
		foreach( GameObject obj in textHolders )
		{
			Color col = obj.guiText.material.color;
			col.a = 0;
			obj.guiText.material.color = col;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			Application.LoadLevel("MenuScene");
		}
			
			
		// Fade in Text
		if( isFadingText )
		{
			if( isFadingIn )
			{
				if( currentFadeInTime <= fadeInTime )
				{
					currentFadeInTime += Time.deltaTime;
					Color col = currentGui.guiText.material.color;
					col.a = currentFadeInTime / fadeInTime;
					currentGui.guiText.material.color = col;
				}	
				else
				{
					isFadingIn = false;
				}
			}
			else
			{
				if( currentFadeInTime >= 0 )
				{
					currentFadeInTime -= Time.deltaTime;
					Color col = currentGui.guiText.material.color;
					col.a = currentFadeInTime / fadeInTime;
					currentGui.guiText.material.color = col;
				}	
				else
				{
					isFadingIn = true;
					isFadingText = false;
				}
			}
		}
		// Wait timer
		else
		{
			currentBetweenTime += Time.deltaTime;
			if( currentBetweenTime >= betweenTime )
			{
				currentBetweenTime = 0;
				// pull in new string
				if( currentStoryIndex == storyChunks.Length)
				{
					StartCoroutine(LoadMainScene());
				}
				else
				{
					string text = storyChunks[currentStoryIndex];
					currentStoryIndex++;
					
					setText(textHolders[currentHolderIndex], text);
					currentHolderIndex++;
				}
				
				if( currentHolderIndex == textHolders.Length)
				{
					currentHolderIndex = 0;
				}
			}
		}
		
	}
	
	private void setText(GameObject gui, string text)
	{
		currentGui = gui;
		currentGui.guiText.text = text;
		
		isFadingText = true;
		
		Color col = currentGui.guiText.material.color;
		col.a = 0;
		currentGui.guiText.material.color = col;
	}
	
	private IEnumerator LoadMainScene()
	{
		yield return new WaitForSeconds(3);
		
		Application.LoadLevel("MenuScene");
	}
	
	
}
