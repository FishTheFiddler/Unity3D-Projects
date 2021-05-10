using UnityEngine;
using System.Collections;

public class FriendlyAI2 : MonoBehaviour {

	public GameObject explosion;
	public GameObject self;
	bool hasCollided = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * 30f, Space.Self);

		if (hasCollided == true){
			transform.Rotate (8,0,0);
			StartCoroutine(collision ());
		}
	
	}

	void OnCollisionEnter(Collision collision){
		hasCollided = true;

	}

	IEnumerator collision(){
		yield return new WaitForSeconds (0.5f);
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (self);
	}
}