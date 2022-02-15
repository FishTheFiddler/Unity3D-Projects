using UnityEngine;
using System.Collections;

/********************************************
 * This class is to define the properties of the weapon (Shotgun)
 * This gun is to be triple shot weapon. slow rate of fire.
 * ******************************************/

public class Shotgun : MonoBehaviour {

	public GameObject player;
	private float fireRate;
	private float lastShot;
	public Rigidbody2D bullet;	
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Rigidbody2D shell;
	public Transform shellSpawn;
	public Transform muzzleSpawn;
	public GameObject muzzleFlash;

	public AudioClip shootSound;

	AudioSource audioData;
	public GameObject gunSprite;
	public Transform gunRotation;
	public int ammo;
	private bool isFlipped = false;
	
	// Use this for initialization
	void Start () {
		fireRate = 1.2f;
		
		audioData = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

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
		
		if (Input.GetMouseButton(0) && player.gameObject.GetComponent<player1> ().canControl == true){
			shoot ();
		}
	}
	
	void shoot(){
		
		if ((Time.time > fireRate + lastShot) && (player.gameObject.GetComponent<player1>().shotgunAmmo > 0)) {
			AudioSource.PlayClipAtPoint(shootSound, new Vector3(1,1,1));
			Instantiate (bullet, spawn1.position, spawn1.rotation);
			Instantiate (bullet, spawn2.position, spawn2.rotation);
			Instantiate (bullet, spawn3.position, spawn3.rotation);
			Instantiate (muzzleFlash, muzzleSpawn.position, muzzleSpawn.rotation);
			Instantiate (shell, shellSpawn.position, shellSpawn.rotation);
			player.gameObject.GetComponent<player1>().shotgunAmmo -= 1;
			lastShot = Time.time;
		}
		
	}
}
