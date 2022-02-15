using UnityEngine;
using System.Collections;

public class greenArrowFish : MonoBehaviour {
	
	public GameObject choiceTop;
	public GameObject choiceMiddle;
	public GameObject choiceBottom;
	private int choiceNum = 1;

	public AudioClip sound;
	// Use this for initialization
	void Start () {
		transform.position = choiceTop.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.DownArrow) && choiceNum == 1) {
			AudioSource.PlayClipAtPoint(sound, new Vector3(1,1,1));
			transform.position = choiceMiddle.gameObject.transform.position;	
			choiceNum++;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow) && choiceNum == 2) {
			AudioSource.PlayClipAtPoint(sound, new Vector3(1,1,1));
			transform.position = choiceBottom.gameObject.transform.position;	
			choiceNum++;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) && choiceNum == 3) {
			AudioSource.PlayClipAtPoint(sound, new Vector3(1,1,1));
			transform.position = choiceMiddle.gameObject.transform.position;
			choiceNum--;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) && choiceNum == 2) {
			AudioSource.PlayClipAtPoint(sound, new Vector3(1,1,1));
			transform.position = choiceTop.gameObject.transform.position;
			choiceNum--;
		}
	}
}
