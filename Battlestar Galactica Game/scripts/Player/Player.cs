using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	// Mouse direction (how much has mouse moved).
	Vector2 mDir;

	// AudioClip clips
	public AudioSource boosterSfx;

	//cameras
	public Camera exteriorCam;
	public Camera launchCam;

	//launchtubes to be despawned
	public GameObject tunnel;
	public GameObject tunnelBound;
	public GameObject catapult;

	//controls
	public float acc = 0.9f;
	public bool canControl = false;
	public GameObject text;
	public float launchDistance = 3f;

	//boundaries
	public Transform centerOfBattlefield;
	public bool outBounds = false;

	//launch sequence
	bool isLaunching;

	// shooting guns
	public Rigidbody bullet;
	public Transform spawn1;
	public Transform spawn2;
	public float fireRate;
	private float lastShot;
	
	// Speed of vehicle.
	public float speed = 20f;

	void Start (){
		Cursor.visible = false;
		isLaunching = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		//this is the launch sequence
		if (Input.GetKeyDown ("space") && !canControl) {
			StartCoroutine (wait ());
			//isLaunching = true;
			Destroy(text);
		}
		if (isLaunching) {
			launch ();
		}

		// once control has been given to the player, call these functions/statements
		if (canControl == true){
			launchCam.enabled = false;
			exteriorCam.enabled = true;
			mouseSteer();
			thrust ();
			speedControl ();
		}

		// firing
		if (Input.GetMouseButton(0) && canControl == true){
			shoot ();
		}
		/*
		//game out of bounds
		if (transform.position.z < -50 && outBounds == false) {
			outBounds = true;
		}
		if (outBounds){
			StartCoroutine (outOfBounds ());
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
			this.transform.LookAt (centerOfBattlefield.position);
		}
	`	*/
	}

	//thrust function to give the ship moving forward no matter what
	void thrust (){
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}

	// this allows the player to slow down or accelerate
	void speedControl (){
		if (Input.GetKey("s")){
			speed = 10f;
		}
		else if (Input.GetKey ("w")) {
			speed = 30f;
		} 
		else {
			speed = 20f;
		}
	}

	// this allows the player to steer with mouse
	void mouseSteer(){
		// What is the new mouse position on screen?
		Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X") * acc,
		                         Input.GetAxisRaw("Mouse Y") * acc);
		
		// Add new movement to current mouse direction.
		mDir += mc;
		
		// Multiply both axes together and rotate this transform.
		this.transform.localRotation =
			Quaternion.AngleAxis (mDir.x, Vector3.up) * 
				Quaternion.AngleAxis (-mDir.y, Vector3.right);
		
	}

	void shoot(){

		if (Time.time > fireRate + lastShot) {
			Instantiate (bullet, spawn1.position, spawn1.rotation);
			Instantiate (bullet, spawn2.position, spawn2.rotation);
			lastShot = Time.time;
		}
		
	}

	void launch(){
		if (isLaunching) {
			catapult.transform.Translate(0,0,-0.4f);
			transform.Translate (Vector3.forward * Time.deltaTime * speed);

			//StartCoroutine (wait ());
		}
	}


	/*
	IEnumerator outOfBounds(){
		canControl = false;
		yield return new WaitForSeconds (4f);
		canControl = true;
		outBounds = false;

	}
	*/
	IEnumerator wait(){
		boosterSfx.Play ();
		yield return new WaitForSeconds (0.9f);
		isLaunching = true;
		Debug.Log ("Launch sequence initiated");
		yield return new WaitForSeconds(launchDistance);
		Destroy (tunnel);
		Destroy (tunnelBound);
		canControl = true;
		isLaunching = false;
	}
}