using UnityEngine;
using System.Collections;

public class Level00 : MonoBehaviour {

	public Transform dialogueSpawn;
	public GameObject dialogue1;

	public GameObject self;
	AudioSource audioData;

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
	

		if (((Input.GetKeyDown(KeyCode.Return)) && canDestroy == true)) {
			//Debug.Log ("test");
			//Debug.Log (canDestroy1);
			player.gameObject.GetComponent<player1> ().canControl = true;
			Destroy (self);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		if (collisionType == "Player") { 
			audioData.Play(0);
			player.gameObject.GetComponent<player1> ().canControl = false;
			spawnDialogue(dialogue1);
		}
	}

	void spawnDialogue(GameObject dialogue){
		Instantiate (dialogue, dialogueSpawn.position, dialogueSpawn.rotation);
		canDestroy = true;
		return;
	}
}
