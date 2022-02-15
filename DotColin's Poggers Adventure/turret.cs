using UnityEngine;
using System.Collections;

public class turret : MonoBehaviour {
	// Enemy stats
	private int health;
	public float fireRate;

	private float lastShot;
	public AudioClip explosionSound;

	public Transform target;
	public Rigidbody2D bullet;
	public GameObject muzzleFlash;
	public GameObject self;
	public Transform spawn1;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		fireRate = 1f;
	}

	void Awake () {
		//target.transform.position = new Vector3 ();
		health = 15;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			AudioSource.PlayClipAtPoint(explosionSound, new Vector3(1,1,1));
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (self);
		}

		shoot();
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

	void shoot(){
		
		if (Time.time > fireRate + lastShot){
			Instantiate (bullet, spawn1.position, spawn1.rotation);
			Instantiate (muzzleFlash, spawn1.position, spawn1.rotation);
			lastShot = Time.time;
		}
	}
}