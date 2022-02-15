using UnityEngine;
using System.Collections;

public class greenArrow : MonoBehaviour {

	public GameObject choiceTop;
	public GameObject choiceBottom;
	private int choiceNum = 1;
	AudioSource audioData;

	// Use this for initialization
	void Start () {
		transform.position = choiceTop.gameObject.transform.position;
		audioData = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.DownArrow) && choiceNum == 1) {
			transform.position = choiceBottom.gameObject.transform.position;	
			audioData.Play (0);
			choiceNum++;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && choiceNum == 2) {
			transform.position = choiceTop.gameObject.transform.position;
			audioData.Play (0);
			choiceNum--;
		}
	}
}
