using UnityEngine;
using System.Collections;

public class winScreen : MonoBehaviour {
	
	public GameObject self;
	public GameObject spawnPoint;
	
	// Use this for initialization
	void Start () {
		
	}
	void Awake () {
		spawnPoint = GameObject.Find ("deathScreenSpawn");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = spawnPoint.gameObject.transform.position;
		if (Input.GetKeyDown(KeyCode.Return)) {
			Destroy (self);
		}
	}
}