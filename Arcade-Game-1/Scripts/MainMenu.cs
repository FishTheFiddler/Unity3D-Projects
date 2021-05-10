using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	// 3 main menu selections
	public Transform pos1;
	public Transform pos2;
	public Transform pos3;

	//whether or not cursor can move
	private bool canMoveUp;
	private bool canMoveDown;

	public AudioSource audioData;
	public AudioSource audioData2;

	// Music situational Variables
	public GameObject musicCheck;

	// Use this for initialization
	void Awake () {
		StartCoroutine(timeDelay2());
		transform.position = pos1.position;
		canMoveUp = false;
		canMoveDown = true;
	
	}

	void Start (){
		//audioData = GetComponent<AudioSource> ();
		//audioData2 = GetComponent<AudioSource> ();
		musicCheck = GameObject.Find("MUSIC(Clone)");
		if (musicCheck != null) {
			Destroy (musicCheck);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.DownArrow) && canMoveUp == false) {
			transform.position = pos2.position;
			canMoveUp = true;
			canMoveDown = true;
			audioData.Play (0);
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow) && canMoveUp == true && canMoveDown == true) {
			transform.position = pos3.position;
			canMoveUp = true;
			canMoveDown = false;
			audioData.Play (0);
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) && canMoveUp == true && canMoveDown == true) {
			transform.position = pos1.position;
			canMoveUp = false;
			canMoveDown = true;
			audioData.Play (0);
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) && canMoveUp == true && canMoveDown == false) {
			transform.position = pos2.position;
			canMoveUp = true;
			canMoveDown = true;
			audioData.Play (0);
		}

		if (Input.GetKeyDown(KeyCode.Space) && transform.position == pos1.position){
			StartCoroutine(timeDelay());
			audioData2.Play (0);
		}
	}

	IEnumerator timeDelay(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel("Level1");
	}
	IEnumerator timeDelay2(){
		yield return new WaitForSeconds (20.0f);
		Application.LoadLevel ("insertCoin");
	}

}