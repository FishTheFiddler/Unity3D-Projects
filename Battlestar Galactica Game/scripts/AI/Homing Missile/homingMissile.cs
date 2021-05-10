using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour {

	public Transform target;
	public GameObject self;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (target.position);
	
	}
	void OnCollisionEnter(Collision collision){
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (self);
	}
}
