using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour {

	/***********************************************************
	 *  Class: player1
	 *  Author: Fish the Fiddler
	 *  Goal: Provide the main infrastructure for player movement
	 *        and collision in the environment. Other functions
	 *        will be created in other classes. 
	 * ********************************************************/


	// Vars for movement and jumping
	[SerializeField] public float moveSpeed;
	[SerializeField] public float jumpForce;

	// vars for determining how fast the player can take damage
	public float damageRate;
	private float lastDamage;

	//audio clip vars
	public AudioClip jumpSound;
	public AudioClip damageSound;
	public AudioClip fallSound;

	// Vars for Colin's face/body  animation and movement
	public GameObject colinFaceIdle;
	public GameObject colinFaceShoot;
	public GameObject colinBodyRun;
	public GameObject colinBodyIdle;
	public GameObject colinBodyJump;
	private bool facingLeft;
	private bool facingRight;

	// Vars for adding ammo to these guns
	public int ak47Ammo;
	public int shotgunAmmo;

	// vars for player death
	public GameObject deathPixels;
	public GameObject deathScreen;
	public Transform deathScreenSpawn;

	// vars for colin's health
	public GameObject heart3;
	public GameObject heart2;
	public GameObject heart1;
	public GameObject empty3;
	public GameObject empty2;
	public GameObject empty1;

	// Vars for Colin's stats
	private int health;
	public GameObject self;
	public bool canControl = true;
	public bool playerAlive = true;

	// Vars for Physics collisions (2D system)
	[SerializeField] private LayerMask platformsLayerMask;
	private Rigidbody2D rigidbody2d;
	private BoxCollider2D boxCollider2d;

	// Initialization Function
	void Start () {
		ak47Ammo = 50;
		shotgunAmmo = 10;
		facingRight = true;
		facingLeft = false;
		jumpForce = 10f;
		rigidbody2d = transform.GetComponent<Rigidbody2D> ();
		boxCollider2d = transform.GetComponent<BoxCollider2D> ();
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Instantiate (deathScreen, deathScreenSpawn.position, deathScreenSpawn.rotation);
			Instantiate (deathPixels, transform.position, transform.rotation);
			self.gameObject.SetActive (false);
			heart1.gameObject.SetActive (false);
			heart2.gameObject.SetActive (false);
			heart3.gameObject.SetActive (false);
			empty3.gameObject.SetActive (true);
			empty2.gameObject.SetActive (true);
			empty1.gameObject.SetActive (true);
			canControl = false;
			playerAlive = false;
			Debug.Log ("OUT OF HEALTH");
		}
		if (health == 1) {
			heart1.gameObject.SetActive (true);
			heart2.gameObject.SetActive (false);
			empty2.gameObject.SetActive (true);
		}
		if (health == 2) {
			heart2.gameObject.SetActive (true);
			heart3.gameObject.SetActive (false);
			empty1.gameObject.SetActive (true);
		}
		if (health == 3) {
			heart3.gameObject.SetActive (true);
			empty1.gameObject.SetActive (false);
		}


		// Animation code utilizing keybindings and booleans
		if (((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))) && !facingLeft && canControl) {
			colinFaceIdle.gameObject.transform.localScale += new Vector3(-2,0,0);
			colinFaceShoot.gameObject.transform.localScale += new Vector3(-2,0,0);
			colinFaceIdle.gameObject.transform.localPosition += new Vector3(-0.2f,0f,0f);
			colinFaceShoot.gameObject.transform.localPosition += new Vector3(-0.2f,0f,0f);
			colinBodyRun.gameObject.transform.localScale += new Vector3(-1,0,0);
			facingLeft = true;
			facingRight = false;
			//	Debug.Log ("Turning Left");
		}
		else if (((Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))) && !facingRight && canControl) {
			colinFaceIdle.gameObject.transform.localScale += new Vector3 (2, 0, 0);
			colinFaceShoot.gameObject.transform.localScale += new Vector3 (2, 0, 0);
			colinFaceIdle.gameObject.transform.localPosition += new Vector3 (0.2f, 0f, 0f);
			colinFaceShoot.gameObject.transform.localPosition += new Vector3 (0.2f, 0f, 0f);
			colinBodyRun.gameObject.transform.localScale += new Vector3 (1, 0, 0);
			facingRight = true;
			facingLeft = false;
			//	Debug.Log ("Turning Right");
		}
		// Jumping animations
		if (((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))) && isGrounded () && canControl) {
			colinBodyIdle.gameObject.SetActive (false);
			colinBodyRun.gameObject.SetActive (true);
			colinBodyJump.gameObject.SetActive (false);
		} 
		else if(!isGrounded () && canControl){
			colinBodyIdle.gameObject.SetActive (false);
			colinBodyJump.gameObject.SetActive (true);
			colinBodyRun.gameObject.SetActive (false);
			//	Debug.Log ("In mid-air");
		}
		else {
			colinBodyIdle.gameObject.SetActive (true);
			colinBodyRun.gameObject.SetActive (false);
			colinBodyJump.gameObject.SetActive (false);
		}

		// Movement from side to side
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0f, 0f);
		if (canControl){
			transform.position += movement * Time.deltaTime * moveSpeed;
		}

		if (((isGrounded() && Input.GetKeyDown(KeyCode.Space))
		     || (isGrounded() && Input.GetKeyDown(KeyCode.W))
		     || (isGrounded() && Input.GetKeyDown(KeyCode.UpArrow))) && canControl) 
		{
			rigidbody2d.velocity = Vector2.up * jumpForce;
			AudioSource.PlayClipAtPoint(jumpSound, new Vector3(1,1,1));
		}

		if (Input.GetMouseButton (0) && canControl) {
			colinFaceShoot.gameObject.SetActive (true);
			colinFaceIdle.gameObject.SetActive (false);
		} else {
			colinFaceIdle.gameObject.SetActive (true);
		}
	}

	public bool isGrounded(){
		RaycastHit2D raycastHit2d = Physics2D.BoxCast (boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, -Vector2.up, .1f, platformsLayerMask);
		//	Debug.Log (raycastHit2d.collider);
		return raycastHit2d.collider != null;
	}

	void OnCollisionEnter2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		{
			if (Time.time > damageRate + lastDamage) {
				switch (collisionType) {
				case "Enemy":
					health -= 1;
					lastDamage = Time.time;
					AudioSource.PlayClipAtPoint(damageSound, new Vector3(1,1,1));
					Instantiate (deathPixels, transform.position, transform.rotation);
					break;
				case "enemyBullet":
					health -= 1;
					lastDamage = Time.time;
					AudioSource.PlayClipAtPoint(damageSound, new Vector3(1,1,1));
					Instantiate (deathPixels, transform.position, transform.rotation);
					break;
				case "ammoBox":
					ak47Ammo += 50;
					shotgunAmmo += 10;
					break;
				}
			}
		}
		if (collisionType == "medPack" && health < 3){ 
			health += 1;
		}
		if (collisionType == "outOfBounds"){
			health -= 3;
			AudioSource.PlayClipAtPoint(fallSound, new Vector3(1,1,1));
			Instantiate (deathPixels, transform.position, transform.rotation);
		}
	}

	void OnCollisionStay2D(Collision2D collision){
		string collisionType = collision.gameObject.tag;
		if ((collisionType == "Enemy") && (Time.time > damageRate + lastDamage)){
			lastDamage = Time.time;
			Instantiate (deathPixels, transform.position, transform.rotation);
			health -= 1;
		}
	}
}