using UnityEngine;
using System.Collections;

public class SwapForm : MonoBehaviour {
	
	public GameObject otherForm;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Space) )
		{
			GameObject obj = Instantiate(otherForm, transform.position, Quaternion.identity) as GameObject;
			obj.name = otherForm.name;
			Destroy(gameObject);
		}
	}
}
