using UnityEngine;
using System.Collections;

public class robot : MonoBehaviour {
	
	private int health;
	
	private float speed = 3f;
	public GameObject self;
	public GameObject explosion;

	// audio variables
	private int explosionNumber;
	public AudioClip explosionSound;
	public AudioClip explosionSound2;
	public AudioClip explosionSound3;
	public AudioClip explosionSound4;


	//animation variables
	public GameObject animationLeft;
	public GameObject animationRight;

	public float leftLimit;
	public float rightLimit;

	private bool movingLeft;
	private bool movingRight;
	
	// Use this for initialization
	void Start () {
	}
	
	void Awake () {
		//target.transform.position = new Vector3 ();
		health = 15;
		movingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {



		if (transform.position.x <= leftLimit){
			movingLeft = false;
			movingRight = true;
		}
		else if (transform.position.x >= rightLimit){
			movingLeft = true;
			movingRight = false;
		}

		if (movingRight){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			animationRight.gameObject.SetActive(true);
			animationLeft.gameObject.SetActive(false);
		}
		else if (movingLeft){
			transform.Translate(Vector2.right * -speed * Time.deltaTime);
			animationRight.gameObject.SetActive(false);
			animationLeft.gameObject.SetActive(true);
		}

		// death
		if (health <= 0) {
			chooseExplosionAudio();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (self);
		}

	}
	
	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		{
			switch (collisionType)
			{
			case "assaultBullet":
				health -= 2;
				break;
			case "shotgunBullet":
				health -= 4;
				break;
			case "handgunBullet":
				health -= 2;
				break;
			}
		}
	}
	void chooseExplosionAudio(){
		explosionNumber = Random.Range(1,5);
		
		{
			switch (explosionNumber)
			{
			case 1:
				AudioSource.PlayClipAtPoint(explosionSound, new Vector3(1,1,1));
				break;
			case 2:
				AudioSource.PlayClipAtPoint(explosionSound2, new Vector3(1,1,1));
				break;
			case 3:
				AudioSource.PlayClipAtPoint(explosionSound3, new Vector3(1,1,1));
				break;
			case 4:
				AudioSource.PlayClipAtPoint(explosionSound4, new Vector3(1,1,1));
				break;
			}
		}
	}
}
