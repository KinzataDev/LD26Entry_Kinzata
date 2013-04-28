using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject[] objectsToSpawn;
	
	public float width = 1;
	public float height = 1;
	
	public float timeBetweenSpawns = 5;
	public float minDistanceToSpawn = 5;
	
	private float timeForSpawn = 0;
	
	private int maxSpawnAttempts = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeForSpawn += Time.deltaTime;
		
		if( timeForSpawn >= timeBetweenSpawns )
		{
			timeForSpawn = 0;
			Spawn();
		}
	}
	
	void Spawn()
	{
		int attempts = 0;
		while( attempts < maxSpawnAttempts)
		{
			attempts++;
			
			float x = (Random.value * width) - (width * 0.5f);
			float z = (Random.value * height) - (height * 0.5f);
			Vector3 point = new Vector3(x,0,z);
			GameObject target = GameObject.FindGameObjectWithTag("Player");
		
			if( target != null )
			{
				Vector3 position = point;
				Vector3 targetPosition = target.transform.position;
				
				Vector3 toVector = targetPosition - position;
				
				toVector.y = 0;
				toVector = toVector.normalized;
				
				RaycastHit hitInfo = new RaycastHit();
				bool rayHit = Physics.Raycast(new Ray(position, toVector), out hitInfo, minDistanceToSpawn);
				if( !rayHit || hitInfo.collider.gameObject.tag != "Player")
				{
					if(!Physics.CheckSphere(point, 0.5f) )//hits.Length == 0 )
					{
						GameObject obj = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
						
						GameObject newObj = Instantiate(obj, point, Quaternion.identity) as GameObject;
						newObj.name = obj.name;
						attempts = maxSpawnAttempts;
					}
				}
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Vector3 position = transform.position;
		
		Gizmos.DrawWireCube(position, new Vector3(width,0,height));
		
		Gizmos.DrawWireSphere(GameObject.FindGameObjectWithTag("Player").transform.position, minDistanceToSpawn);
	}
}
