using UnityEngine;
using System.Collections;

public class blinkingText : MonoBehaviour {

	private bool canChange = true;
	public GameObject text;
	public string SceneToLoad;

	// Use this for initialization
	void Start () {
		StartCoroutine(blink ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Return)){
			Application.LoadLevel(SceneToLoad);
		}
	}

	IEnumerator blink(){
		while(canChange){
		yield return new WaitForSeconds(0.5f);
		text.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		text.gameObject.SetActive(true);
		}
	}
}
