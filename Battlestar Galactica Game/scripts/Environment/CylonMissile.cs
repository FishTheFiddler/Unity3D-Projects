using UnityEngine;
using System.Collections;

public class CylonMissile : MonoBehaviour {

	public float speed;
	public GameObject self;
	public GameObject explosion;
	int limit;

	// Use this for initialization
	void Start () {
		limit = Random.Range (50,180);
		//Debug.Log (limit);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//transform.Translate (0, 0, speed);

		if (transform.position.z < limit) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (self);


		}

	

		
		
	}

}
