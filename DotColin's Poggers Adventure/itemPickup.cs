using UnityEngine;
using System.Collections;

public class itemPickup : MonoBehaviour {


	public GameObject pixelBurst;
	public GameObject text;
	//AudioSource audioData;
	public AudioClip pickup;
	// Use this for initialization
	void Start () {
		//audioData = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		if (collisionType == "Player") { 
			AudioSource.PlayClipAtPoint(pickup, new Vector3(1,1,1));
			Instantiate (pixelBurst, transform.position, transform.rotation);
			Instantiate (text, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}	
}
