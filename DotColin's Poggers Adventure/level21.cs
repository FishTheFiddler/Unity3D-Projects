using UnityEngine;
using System.Collections;

public class level21 : MonoBehaviour {
	
	public Transform dialogueSpawn;
	public Transform fishDialogueSpawn;
	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject dialogue3;
	public GameObject dialogue4;
	public GameObject dialogue5;
	public GameObject dialogue6;
	public GameObject dialogue7;
	public GameObject dialogue8;
	
	public GameObject self;
	private bool topChoice = true;
	private bool middleChoice = false;
	
	private int dialogueNum;
	public bool canDestroy = false;
	
	public GameObject player;
	
	
	
	// Use this for initialization
	void Start () {
		dialogueNum = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//Navigation		
		if(Input.GetKeyDown(KeyCode.DownArrow) && !middleChoice && topChoice) {
			topChoice = false;
			middleChoice = true;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow) && middleChoice && !topChoice) {
			topChoice = false;
			middleChoice = false;
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) && middleChoice && !topChoice) {
			topChoice = true;
			middleChoice = false;
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) && !middleChoice && !topChoice) {
			topChoice = false;
			middleChoice = true;
		}

		/**************************************************************/
		// FIRST DIALOGUE appears, when pressing enter, load second one
		if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1)) {
			spawnDialogue(dialogue2);
			dialogueNum++;
		}

		// SECOND DIALOGUE appears, when pressing enter, load third one
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 2)) {
			spawnFishDialogue(dialogue3);
			dialogueNum++;
		}
		// THIRD DIALOGUE appears, when pressing enter, load third one
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 3)) {
			spawnDialogue(dialogue4);
			dialogueNum++;
		}
		// FOURTH DIALOGUE appears, when pressing enter, load fifth one
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 4)) {
			spawnDialogue(dialogue5);
			dialogueNum++;
		}

		// FIFTH DIALOGUE appears,.. This one has multiple choices!
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 5) && topChoice) {
			spawnFishDialogue(dialogue6);
			dialogueNum = 6;
		}
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 5) && middleChoice) {
			spawnFishDialogue(dialogue7);
			dialogueNum = 7;
		}
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 5) && !topChoice && !middleChoice) {
			spawnFishDialogue(dialogue8);
			dialogueNum = 8;
		}

		// this happens if dialogue number is 6 OR 7
		else if ((Input.GetKeyDown(KeyCode.Return)) && ((dialogueNum == 6) || (dialogueNum == 7))) {
			spawnDialogue(dialogue5);
			middleChoice = false;
			topChoice = true;
			dialogueNum = 5;
		}

		//The last dialogue box to end the conversation.
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 8)) {
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
			spawnFishDialogue(dialogue1);
			dialogueNum++;
		}
	}
	
	void spawnDialogue(GameObject dialogue){
		Instantiate (dialogue, dialogueSpawn.position, dialogueSpawn.rotation);
		return;
	}
	void spawnFishDialogue(GameObject dialogue){
		Instantiate (dialogue, fishDialogueSpawn.position, fishDialogueSpawn.rotation);
		return;
	}
}