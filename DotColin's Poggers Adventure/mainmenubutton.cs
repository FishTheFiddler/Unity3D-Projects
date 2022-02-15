using UnityEngine;
using System.Collections;

public class mainmenubutton : MonoBehaviour {

	public GameObject button1;
	public GameObject button2;

	public GameObject mainScreen;
	public GameObject levelSelect;
	public GameObject noteToPlayer;

	public string buttonText;
	public AudioClip mouseOverSound;
	public AudioClip mouseClickSound;

	private bool selected = false;
	public GameObject description;

	// Use this for initialization
	void Start () {
		button1.gameObject.SetActive(true);
		button2.gameObject.SetActive(false);
		description.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && selected){
			{	switch (buttonText)
				{
				case "Play Game":
					Application.LoadLevel("Prologue");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					break;
				case "Note to Player":
					mainScreen.gameObject.SetActive(false);
					noteToPlayer.gameObject.SetActive(true);
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					selected = false;
					break;
				case "Level Select":
					mainScreen.gameObject.SetActive(false);
					levelSelect.gameObject.SetActive(true);
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					selected = false;
					break;
				case "Credits":
					Application.LoadLevel("Credits");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					selected = false;
					break;
				case "Main Menu":
					Application.LoadLevel("Main Menu");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					selected = false;
					break;
				case "Back":
					noteToPlayer.gameObject.SetActive(false);
					levelSelect.gameObject.SetActive(false);
					mainScreen.gameObject.SetActive(true);
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					selected = false;
					break;
				case "Level 1":
					Application.LoadLevel("Level1");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					break;
				case "Level 2":
					Application.LoadLevel("Level2");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					break;
				case "Level 3":
					Application.LoadLevel("Level2-1");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					break;
				case "Quit":
					Application.Quit();
					Debug.Log("Quitting Game");
					AudioSource.PlayClipAtPoint(mouseClickSound, new Vector3(1,1,1));
					break;
				}
			}
			//Debug.Log(text);
		}
	}

	void OnMouseOver(){
		button1.gameObject.SetActive(false);
		button2.gameObject.SetActive(true);
		description.gameObject.SetActive(true);
		selected = true;
	}
	void OnMouseExit(){
		button1.gameObject.SetActive(true);
		button2.gameObject.SetActive(false);
		description.gameObject.SetActive(false);
		selected = false;
	}
	void OnMouseEnter(){
		AudioSource.PlayClipAtPoint(mouseOverSound, new Vector3(1,1,1));
	}
}
