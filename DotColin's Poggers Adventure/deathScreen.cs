using UnityEngine;
using System.Collections;

public class deathScreen : MonoBehaviour {

	private bool restartChoice = true;
	public Transform choice1;
	public Transform choice2;
	public Transform arrow;
	public string sceneToLoad;
	public AudioClip moveSound;
	public GameObject spawnPoint;



	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.Find("deathScreenSpawn");
		arrow.transform.position = choice1.position;

	}
	
	// Update is called once per frame
	void Update () {

		// keep it moving with the camera
		transform.position = spawnPoint.gameObject.transform.position;

		// selecting choices
		if (Input.GetKeyDown(KeyCode.Return) && restartChoice){
			Application.LoadLevel(sceneToLoad);
		}
		else if (Input.GetKeyDown(KeyCode.Return) && !restartChoice){
			Application.LoadLevel("Main Menu");
		}

		// moving cursor
		if (Input.GetKeyDown(KeyCode.DownArrow) && restartChoice){
			arrow.transform.position = choice2.position;
			AudioSource.PlayClipAtPoint(moveSound, new Vector3(1,1,1));
			restartChoice = false;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) && !restartChoice){
			arrow.transform.position = choice1.position;
			AudioSource.PlayClipAtPoint(moveSound, new Vector3(1,1,1));
			restartChoice = true;
		}


	
	}
}
