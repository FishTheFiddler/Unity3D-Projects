using UnityEngine;
using System.Collections;

public class level21p2 : MonoBehaviour {
	
	public Transform dialogueSpawn;
	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject self;
	public GameObject gun;

	public bool canDestroy = false;
	private int dialogueNum;
	
	public GameObject player;
	
	
	
	// Use this for initialization
	void Start () {
		dialogueNum = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {

		//The first dialogue box 
		if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 1)) {
			spawnDialogue(dialogue2);
		} 
		//second one spawns in and can now be temrinated.
		else if ((Input.GetKeyDown(KeyCode.Return)) && (dialogueNum == 2)) {
			canDestroy = true;
		} 
		
		if (canDestroy) {
			player.gameObject.GetComponent<player1> ().canControl = true;
			gun.gameObject.GetComponent<Gun> ().pepeUnlocked = true;
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
		Instantiate (dialogue, dialogueSpawn.position, dialogueSpawn.rotation);
		dialogueNum++;
		return;
	}
}