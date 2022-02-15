using UnityEngine;
using System.Collections;

public class fishDialogueBox : MonoBehaviour {
	
	public GameObject self;
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Destroy (self);
		}
	}
}