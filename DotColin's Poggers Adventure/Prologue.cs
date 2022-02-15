using UnityEngine;
using System.Collections;

public class Prologue : MonoBehaviour {
	
	public Transform dialogueSpawn;
	public Transform videoSpawn;
	public Transform videoSpawn2;

	public string sceneToLoad;
	AudioSource audioData;

	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject dialogue3;
	public GameObject dialogue4;
	public GameObject dialogue5;
	public GameObject dialogue6;
	public GameObject dialogue7;
	public GameObject dialogue8;

	public GameObject videoStatic;
	public GameObject video1;
	public GameObject video2;
	public GameObject video3;
	public GameObject video4;
	public GameObject video5;
	public GameObject video6;
	
	public GameObject self;

	private bool canAdvanceText;
	private int dialogueNum;
	private int videoNum;

	
	// Use this for initialization
	void Start () {
		canAdvanceText = false;
		videoNum = 0;
		dialogueNum = 0;
		audioData = GetComponent<AudioSource> ();
	}

	void Awake () {
		StartCoroutine (begin());
	}
	
	// Update is called once per frame
	void Update () {

		
		/**************************************************************/
		// FIRST DIALOGUE appears, when pressing enter, load second one
		if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1) && (videoNum == 1) && canAdvanceText) {
			spawnVideo(video2);
			spawnDialogue(dialogue2);
			dialogueNum++;
			videoNum++;
		}

		// SECOND DIALOGUE appears, when pressing enter, load Third one
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 2) && (videoNum == 2)) {
			spawnVideo(video3);
			spawnDialogue(dialogue3);
			dialogueNum++;
			videoNum++;
		}
		// THIRD DIALOGUE appears, when pressing enter, load fourth dialogue, but keep third video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 3) && (videoNum == 3)) {
			spawnVideo(video3);
			spawnDialogue(dialogue4);
			dialogueNum++;
		}
		// FOURTH DIALOGUE appears, when pressing enter, load fifth fialogue and fourth video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 4) && (videoNum == 3)) {
			spawnDialogue(dialogue5);
			spawnVideo(video4);
			dialogueNum++;
			videoNum++;
		}
		// FIFTH DIALOGUE appears, when pressing enter, load sixth dialogue and fifth video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 5) && (videoNum == 4)) {
			spawnDialogue(dialogue6);
			Instantiate (video5, videoSpawn2.position, videoSpawn2.rotation);
			dialogueNum++;

		}
		// SIXTH DIALOGUE appears, when pressing enter, load seventh dialogue but keep fifth video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 6) && (videoNum == 4)) {
			spawnDialogue(dialogue7);
			Instantiate (video5, videoSpawn2.position, videoSpawn2.rotation);
			dialogueNum++;
			videoNum++;
		}
		// SEVENTH DIALOGUE appears, when pressing enter, load seventh dialogue but keep fifth video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 7) && (videoNum == 5)) {
			spawnDialogue(dialogue8);
			spawnVideo(video6);
			videoNum++;
			dialogueNum++;
		}
		// EIGHTH DIALOGUE appears, when pressing enter, remove last dialogue and remove last video
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 8) && (videoNum == 6)) {
			videoStatic.gameObject.SetActive (true);
			Debug.Log ("end of cinematics");
			StartCoroutine (end());
		}
		

	}

	void spawnDialogue(GameObject dialogue){
		audioData.Play(0);
		Instantiate (dialogue, dialogueSpawn.position, dialogueSpawn.rotation);
		return;
	}
	void spawnVideo(GameObject video){
		Instantiate (video, videoSpawn.position, transform.rotation);
		return;
	}
	IEnumerator begin(){
		yield return new WaitForSeconds (2f);
		// Static screen appears then dissappears to reveal the first screen
		videoStatic.gameObject.SetActive (false);
		spawnDialogue(dialogue1);
		spawnVideo(video1);
		dialogueNum++;
		videoNum++;
		canAdvanceText = true;
	}
	IEnumerator end(){
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (sceneToLoad);
		
	}
}