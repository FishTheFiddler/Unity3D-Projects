using UnityEngine;
using System.Collections;

public class musicCheck : MonoBehaviour {
	

	// Music situational Variables
	public GameObject music;
	public string musicName;
	//public GameObject musicReal;

	
	void Awake(){
	}
	
	// Use this for initialization
	void Start () {

		music = GameObject.Find(musicName);

		
		if (music == null) {
			Debug.Log ("No Music to destroy - Moving on");
		}
		else{
			Debug.Log("Music track found - destroying");
			Destroy(music);
		}
	}
	
	// Update is called once per frame
	void Update() {

		
	}

}