using UnityEngine;
using System.Collections;

/********************************************
 * This class is to define the properties of the weapon (handgun)
 * This gun is to be a semi-automatic handgun. regular rate of fire. Nothing exciting.
 * ******************************************/

public class handgun : MonoBehaviour {

	public GameObject player;
	public float fireRate;
	private float lastShot;
	public Rigidbody2D bullet;
	public Rigidbody2D shell;
	public Transform spawn1;
	public Transform shellSpawn;
	public GameObject muzzleFlash;

	AudioSource audioData;
	public GameObject gunSprite;
	public Transform gunRotation;
	private bool isFlipped = false;

	//public Animator animator;
	//public Animation animation;

	// Use this for initialization
	void Start () {
		fireRate = 0.5f;
		audioData = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((gunRotation.rotation.z > 0.7 && !isFlipped) || (gunRotation.rotation.z < -0.7 && !isFlipped)) {
			// Debug.Log ("success");
			gunSprite.gameObject.transform.localScale += new Vector3 (0,-2,0); 
			gunSprite.gameObject.transform.localPosition += new Vector3 (0,0.15f,0);
			isFlipped = true;
		}
		if (gunRotation.rotation.z < 0.7 && gunRotation.rotation.z > -0.7 && isFlipped) {
			// Debug.Log ("success");
			gunSprite.gameObject.transform.localScale += new Vector3 (0,2,0); 
			gunSprite.gameObject.transform.localPosition += new Vector3 (0,-0.15f,0);
			isFlipped = false;
		}

		if (Input.GetMouseButton(0) && player.gameObject.GetComponent<player1> ().canControl == true){
			shoot ();
		}

	}

	void shoot(){
		
		if (Time.time > fireRate + lastShot){
			audioData.Play (0);
			Instantiate (bullet, spawn1.position, spawn1.rotation);
			Instantiate (muzzleFlash, spawn1.position, spawn1.rotation);
			Instantiate (shell, shellSpawn.position, shellSpawn.rotation);
			lastShot = Time.time;
		}
		
	}

}
