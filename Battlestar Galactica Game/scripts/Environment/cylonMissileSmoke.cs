using UnityEngine;
using System.Collections;

public class cylonMissileSmoke : MonoBehaviour {

	public float speed;
	public ParticleSystem smoke;
	public GameObject self;
	public bool emitting = true;
	int limit;

	// Use this for initialization
	void Start () {
		limit = Random.Range (50,180);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (0, 0, speed);

		if (transform.position.z < limit && emitting == true) {
			StartCoroutine(stopEmitting ());

		}
	}

	IEnumerator stopEmitting(){
		emitting = false;
		smoke.Stop ();
		yield return new WaitForSeconds (6);
		Destroy (self);
	}
}
