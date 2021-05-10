using UnityEngine;
using System.Collections;

public class finalScore : MonoBehaviour {

	GameObject masterScript;
	string display;
	void Awake() {
		masterScript = GameObject.Find("GameMaster");
	}
	void Start () {
	//	display = (masterScript.GetComponent<gameMaster> ().score).ToString ();
	//	GetComponent<TextMesh> ().text = display;
	}
	
	// Update is called once per frame
	void Update () {
		display = (masterScript.GetComponent<gameMaster> ().score).ToString ();
		GetComponent<TextMesh> ().text = display;
	}
}
