using UnityEngine;
using System.Collections;

public class crosshairscript : MonoBehaviour {
	
	private Vector3 mousePosition;
	public float moveSpeed = 2f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		  	transform.position = mousePosition;
	}
}