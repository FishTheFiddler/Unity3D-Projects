using UnityEngine;
using System.Collections;

public class Terrainscript : MonoBehaviour {

	[SerializeField] float speed;
	public float lifetime;
	public float spawnTime;
	public bool canDestroy;
	// Use this for initialization
	void Start () {
		lifetime = spawnTime + 20.0f;
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (-speed, 0.0f, 0.0f);

		if (Time.time > lifetime + spawnTime && canDestroy) {
			Destroy(gameObject) ;

		}
	}
}