using UnityEngine;
using System.Collections;

public class shell : MonoBehaviour {
	public GameObject self;
	private Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
		rigidbody2d = transform.GetComponent<Rigidbody2D> ();
		rigidbody2d.velocity = Vector2.up * 4;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, 2);
		Destroy (self, 0.7f);
	}
}
