using UnityEngine;

using System.Collections;

public class assaultBullet : MonoBehaviour {

	public float speed;
	public GameObject self;
	public GameObject sparks;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
		Destroy (self, 1f);
	}
	void OnCollisionEnter2D(Collision2D collision){
		Instantiate (sparks, transform.position, transform.rotation);
		Destroy (self);
	}
}
