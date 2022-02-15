using UnityEngine;
using System.Collections;

public class videoController : MonoBehaviour {
	
	//int time;
	//int limit = 30;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame

	void Update () {

		Renderer r = GetComponent<Renderer>();
		MovieTexture movie = (MovieTexture)r.material.mainTexture;
		movie.Play();
		movie.loop = true;

		/*if(Input.GetKeyDown(KeyCode.A)){
			Application.LoadLevel("Main Menu");

		}*/

	}

		

}