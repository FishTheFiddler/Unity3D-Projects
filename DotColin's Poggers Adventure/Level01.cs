using UnityEngine;
using System.Collections;

public class Level01 : MonoBehaviour {
	
	public Transform dialogueSpawn;
	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject dialogue3;
	public GameObject dialogue4;

	// public GameObject arrow;
	//public Transform dialogueChoiceUp;
	// public Transform dialogueChoiceDown;
	AudioSource audioData;
	private bool topChoice = true;
	
	public GameObject self;
	
	private int dialogueNum;
	public bool canDestroy = false;
	
	public GameObject player;
	
	
	
	// Use this for initialization
	void Start () {
		dialogueNum = 0;		
		audioData = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Navigation		
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			topChoice = false;
		}
	
		else if(Input.GetKeyDown(KeyCode.UpArrow)) {
			topChoice = true;
		}

		/**************************************************************/



		if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1) && (topChoice)) {
			spawnDialogue(dialogue2);
		}
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1) && (!topChoice)) {
			spawnDialogue(dialogue3);
		}
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 2)) {
			spawnDialogue(dialogue4);
		}
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 3)) {
			canDestroy = true;
		}

		if (canDestroy) {
			player.gameObject.GetComponent<player1> ().canControl = true;
			Destroy (self);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		if (collisionType == "Player") { 
			player.gameObject.GetComponent<player1> ().canControl = false;
			spawnDialogue(dialogue1);
		}
	}
	
	void spawnDialogue(GameObject dialogue){
		audioData.Play (0);
		Instantiate (dialogue, dialogueSpawn.position, dialogueSpawn.rotation);
		dialogueNum++;
		//topChoice = true;
		return;
	}
}