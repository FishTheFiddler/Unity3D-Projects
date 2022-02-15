using UnityEngine;
using System.Collections;

public class Level01p2 : MonoBehaviour {
	
	public Transform dialogueSpawn;
	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject dialogue3;
	public GameObject self;
	public GameObject gun;
	
	private int dialogueNum;
	public bool canDestroy = false;
	AudioSource audioData;
	
	public GameObject player;
	
	
	
	// Use this for initialization
	void Start () {
		dialogueNum = 0;
		audioData = GetComponent<AudioSource> ();		
	}
	
	// Update is called once per frame
	void Update () {
		/**************************************************************/
		

		if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1)) {
			spawnDialogue(dialogue2);
		}

		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 2)) {
			spawnDialogue(dialogue3);
		}

		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 3)) {
			canDestroy = true;
		} 

		if (canDestroy) {
			player.gameObject.GetComponent<player1> ().canControl = true;
			gun.gameObject.GetComponent<Gun> ().weaponsUnlocked = true;
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
		//Debug.Log ("line 78 - " + dialogueNum);
		dialogueNum++;
		//Debug.Log ("line 86 - " + dialogueNum);
		//topChoice = true;
		return;
	}
}