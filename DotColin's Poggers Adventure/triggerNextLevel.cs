using UnityEngine;
using System.Collections;

public class triggerNextLevel : MonoBehaviour {

	public string sceneToLoad;
	public GameObject prompt;
	
	// Use this for initialization
	void Start () {
		prompt.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D collision){
		if( collision.gameObject.tag == "Player"){
			prompt.gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			Application.LoadLevel(sceneToLoad);
		}
	}
	void OnTriggerExit2D(Collider2D collision){
		if( collision.gameObject.tag == "Player"){
			prompt.gameObject.SetActive(false);
		}
	}
}