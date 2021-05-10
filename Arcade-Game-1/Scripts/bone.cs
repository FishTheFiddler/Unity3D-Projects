using UnityEngine;
using System.Collections;

public class bone : MonoBehaviour {



	public GameObject masterScript;
	[SerializeField] private GameObject points;
	[SerializeField] private GameObject pixelburst;


	// Use this for initialization

	void Awake(){
		masterScript = GameObject.Find("GameMaster");

	}

	void OnCollisionEnter2D(Collision2D collision){
		masterScript.GetComponent<gameMaster> ().score += 100;
//		Debug.Log ("bone collected...score is now " + masterScript.GetComponent<gameMaster> ().score);
		Instantiate (points, transform.position, transform.rotation);
		Instantiate (pixelburst, transform.position,transform.rotation);
		Destroy (gameObject);
	}
}
