using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private LayerMask platformsLayerMask;
	[SerializeField] private float speed;
	private Rigidbody2D rigidbody2d;
	private BoxCollider2D boxCollider2d;
	AudioSource audioData;

	// Use this for initialization
	private void Awake () {
		audioData = GetComponent<AudioSource> ();
		rigidbody2d = transform.GetComponent<Rigidbody2D> ();
		boxCollider2d = transform.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(-speed, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(speed, 0, 0);
		}


		if (isGrounded() && Input.GetKeyDown (KeyCode.Space)) 
		{
			audioData.Play(0);
			float jumpVelocity = 4f;
			rigidbody2d.velocity = Vector2.up * jumpVelocity;

		}
	}
	public bool isGrounded(){
		RaycastHit2D raycastHit2d = Physics2D.BoxCast (boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, -Vector2.up, .1f, platformsLayerMask);
	//	Debug.Log (raycastHit2d.collider);
		return raycastHit2d.collider != null;
	}
}
