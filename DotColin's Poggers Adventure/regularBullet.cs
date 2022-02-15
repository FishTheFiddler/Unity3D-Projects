using UnityEngine;
using System.Collections;

public class regularBullet : MonoBehaviour {

	public GameObject sparks;
	public float speed;
	//private Rigidbody2D rb;
	public GameObject self;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D>();
		speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 tempVect = new Vector3(1, 0, 0);
		tempVect = tempVect.normalized * speed * Time.deltaTime;
		rb.MovePosition(transform.position + tempVect);
		*/
		transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
		Destroy (self, 1.2f);
	}
	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		Instantiate (sparks, transform.position, transform.rotation);
			switch (collisionType)
			{
			case "Enemy":
				Instantiate (sparks, transform.position, transform.rotation);
				Destroy(self);;
				break;
			case "enemyBullet":
				Instantiate (sparks, transform.position, transform.rotation);
				Destroy(self);;
				break;
			case "Player":
				// health -= 1;
				Destroy(self);
				break;
			case "terrain":
				// health -= 1;
				Destroy(self);
				Instantiate (sparks, transform.position, transform.rotation);
				break;
			}

	}
}
