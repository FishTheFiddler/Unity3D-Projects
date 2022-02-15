using UnityEngine;
using System.Collections;

public class videoSpawnDelete : MonoBehaviour {
	
	public GameObject self;
	
	// Use this for initialization
	void Start () {
		
	}
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Destroy (self);
		}
	}
}