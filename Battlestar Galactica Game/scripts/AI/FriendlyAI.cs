using UnityEngine;
using System.Collections;

public class FriendlyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * 30f);
		transform.Rotate (0.0f, 0.0f, 0.2f);
	}
}
