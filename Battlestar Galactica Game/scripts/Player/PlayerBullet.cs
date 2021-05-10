using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	public float speed = 1;
	public GameObject self;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector3.up * Time.deltaTime * speed);
		Destroy (self, 1);

	}
}
