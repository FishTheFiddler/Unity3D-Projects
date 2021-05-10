using UnityEngine;
using System.Collections;

public class movementdestroy : MonoBehaviour {
	
	float lifetime;
	float spawnTime;
	public float xspeed;
	public float yspeed;
	public float lifetimer;
	
	// Use this for initialization
	void Start () {
		lifetime = spawnTime + lifetimer;
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	private void Update () {
		transform.Translate(-xspeed, yspeed, 0.0f);
		if (Time.time > lifetime + spawnTime) {
			Destroy(gameObject) ;
		}
	}
}