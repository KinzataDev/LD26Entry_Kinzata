using UnityEngine;
using System.Collections;

public class PowerLimit : MonoBehaviour {

	public static int numPowersUsed = 0;
	
	public static void Reset()
	{
		numPowersUsed = 0;
	}
}
