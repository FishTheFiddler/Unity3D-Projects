using UnityEngine;
using System.Collections;

public class pickupText : MonoBehaviour {


	private float speed = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
	
		Destroy (gameObject, 1f);
	}
}
