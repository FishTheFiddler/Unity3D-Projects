using UnityEngine;
using System.Collections;

public class musicLevel1 : MonoBehaviour {
	
	
	// Music situational Variables
	public GameObject music;
	public string musicName;
	public GameObject musicToSpawn;
	
	
	void Awake(){
	}
	
	// Use this for initialization
	void Start () {
		
		music = GameObject.Find(musicName);
		
		
		if (music == null) {
			Instantiate (musicToSpawn);
			Debug.Log ("No Music found - creating music.");
		}
		else{
			Debug.Log ("Music already exists - moving forward.");
		}
	}
	
	// Update is called once per frame
	void Update() {
		
		
	}
	
}