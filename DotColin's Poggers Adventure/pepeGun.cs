using UnityEngine;
using System.Collections;

/********************************************
 * This class is to define the properties of the weapon (automatic)
 * This gun is to be a rapid fire, low damage weapon
 * ******************************************/

public class pepeGun: MonoBehaviour {
	
	private float fireRate;
	private float lastShot;
	public Rigidbody2D bullet;
	public Transform spawn1;
	public Rigidbody2D shell;
	public Transform shellSpawn;
	public GameObject muzzleFlash;
	public GameObject player;

	public AudioClip shootSound;
	
	public GameObject gunSprite;
	public Transform gunRotation;
	private bool isFlipped = false;
	
	// Use this for initialization
	void Start () {
		fireRate = 0.25f;
		//ammo = player.gameObject.GetComponent<player1>().ak47Ammo;
	}
	
	// Update is called once per frame
	void Update () {
		
		//ammo = player.gameObject.GetComponent<player1>().ak47Ammo;
		
		if ((gunRotation.rotation.z > 0.7 && !isFlipped) || (gunRotation.rotation.z < -0.7 && !isFlipped)) {
			// Debug.Log ("success");
			gunSprite.gameObject.transform.localScale += new Vector3 (0,-11.474f,0);
			gunSprite.gameObject.transform.localPosition += new Vector3 (0,0.8f,0);
			isFlipped = true;
		}
		if (gunRotation.rotation.z < 0.7 && gunRotation.rotation.z > -0.7 && isFlipped) {
			// Debug.Log ("success");
			gunSprite.gameObject.transform.localScale += new Vector3 (0,11.474f,0); 
			gunSprite.gameObject.transform.localPosition += new Vector3 (0,-0.8f,0);
			isFlipped = false;
		}
		
		if (Input.GetMouseButton(0)){
			shoot ();
		}
	}
	
	void shoot(){
		
		if ((Time.time > fireRate + lastShot)) {
			AudioSource.PlayClipAtPoint(shootSound, new Vector3(1,1,1));
			Instantiate (bullet, spawn1.position, spawn1.rotation);
			Instantiate (muzzleFlash, spawn1.position, spawn1.rotation);
			Instantiate (shell, shellSpawn.position, shellSpawn.rotation);

			lastShot = Time.time;
		}
		
	}
}
