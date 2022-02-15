using UnityEngine;
using System.Collections;

public class Muzzleflash : MonoBehaviour {

	public GameObject self;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//parent = Transform.Find("Handgun");
		Destroy (self, 0.03f);
	}
}
