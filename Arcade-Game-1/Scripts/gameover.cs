using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour {
	public Transform arrow;
	public Transform pos1;
	public Transform pos2;
	public AudioSource audioData;
	public AudioSource audioData2;
	bool gameOver;


	void Start () {
		audioData = GetComponent<AudioSource>();
		audioData2 = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow)){
			arrow.position = pos2.position;
			audioData.Play(0);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			arrow.position = pos1.position;
			audioData.Play (0);
		}

		if (Input.GetKeyDown(KeyCode.Space) && arrow.position == pos2.position){
			Application.LoadLevel("Main Menu");
		}
		if (Input.GetKeyDown(KeyCode.Space) && arrow.position == pos1.position){
			Application.LoadLevel ("Level1");
		}
			

	
	}
}
