using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	private float speed = 0.65f;
	// Use this for initialization
	void Start () {

		StartCoroutine(exitToMenu());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	IEnumerator exitToMenu(){
		yield return new WaitForSeconds(77f);
		Application.LoadLevel ("Main Menu");
	}
}
