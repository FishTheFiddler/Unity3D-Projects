using UnityEngine;
using System.Collections;

public class Levelgenerator2 : MonoBehaviour {

	[SerializeField] public GameObject[] prefabs;
	private int randomPrefab;
	
	public float spawnRate;
	public float lastSpawn;
	
	void Start()
	{

	}
	// Update is called once per frame
	void Update () {
			
			if (Time.time > spawnRate + lastSpawn) {
				//Instantiate (Prefab1, transform.position, transform.rotation);
				randomPrefab = Random.Range(0, 6);
				Instantiate(prefabs[randomPrefab],transform.position, transform.rotation);
				lastSpawn = Time.time;
			}
			
		}
	
	}

