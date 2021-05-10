using UnityEngine;
using System.Collections;

public class backgroundScrolling : MonoBehaviour {


	Material material;
	Vector2 offset;

	public float xSpeed;
	public float ySpeed;
	private void Awake()
	{
		material = GetComponent<Renderer>().material;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (xSpeed, ySpeed);
		material.mainTextureOffset += offset * Time.deltaTime;
	}
}
