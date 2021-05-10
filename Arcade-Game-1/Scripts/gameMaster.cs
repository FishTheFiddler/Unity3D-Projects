using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {


	
	// Game over variables
	GameObject gameOverScript;
	public GameObject gameOverMenu;
	public Transform playerPos;
	public GameObject player;
	bool canKillPlayer;
	AudioSource audioData;

	// Music situational Variables
	public GameObject musicCheck;
	public GameObject musicReal;

	// GLOBAL Score Variable
	public int highscore;
	public int score;

	// Opening "Game Start" text variables
	public GameObject levelStartText;
	public float lifetime;
	public float spawnTime;
	
	void Awake(){
	}

	// Use this for initialization
	void Start () {
		canKillPlayer = true;
		musicCheck = GameObject.Find("MUSIC(Clone)");
		audioData = GetComponent<AudioSource> ();
		score = 0;	
		highscore = PlayerPrefs.GetInt("Highscore");
		lifetime = spawnTime + 3.0f;
		spawnTime = Time.time;
		openingText ();

		if (musicCheck == null) {
			Instantiate (musicReal);
		}
	}
	
	// Update is called once per frame
	void Update() {
		if (canKillPlayer) {
			if (playerPos.position.y < 1.3 && canKillPlayer) {
				canKillPlayer = false;
				audioData.Play (0);
				Instantiate(gameOverMenu);
				if (score > highscore){
					PlayerPrefs.SetInt ("Highscore", score);
				}
			}
		}

	}
	//function used for opening text "Game Start" 
	private void openingText(){
		bool canSpawn = true;
		if (canSpawn) {
			Instantiate(levelStartText);
			canSpawn = false;
		}
	}

	public void recordHighscore(){

	}

	public void readHighscore (){
	
	}
}