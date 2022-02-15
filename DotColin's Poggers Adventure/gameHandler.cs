using UnityEngine;
using System.Collections;

public class gameHandler : MonoBehaviour {
	/*
	int width = 2560; // or something else
	int height = 1440; // or something else
	bool isFullScreen = true; // should be windowed to run in arbitrary resolution
	int desiredFPS = 60; // or something else
*/
	// Use this for initialization

	public Texture2D cursorTarget;
	void Start () {
		setResolution(2560, 1440, true, 60);
		//Cursor.visible = false;
		//Cursor.SetCursor (cursorTarget, Vector2.zero, CursorMode.ForceSoftware);
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if (Input.GetKeyDown (KeyCode.I)) {
			//width +=  360;
			//height += 640;
			//Debug.Log("sent");
			setResolution(2560, 1440, true, 60);
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			//width -=  360;
			//height -= 640;
			setResolution(1024, 576, true, 60);
		}*/ 
	}

	void setResolution(int width, int height, bool isFullScreen, int desiredFPS){
		Screen.SetResolution (width , height, isFullScreen, desiredFPS );
		Debug.Log("-Setting Resolution-");
	}
}
