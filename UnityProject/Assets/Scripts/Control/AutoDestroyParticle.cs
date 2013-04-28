using UnityEngine;
using System.Collections;

public class AutoDestroyParticle : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
		if ( !gameObject.GetComponent<ParticleSystem>().IsAlive() )
		{
			Destroy(gameObject);
		}
	}
}
