using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour {

	Vector3 mouse_pos;
	Vector3 object_pos;
	Transform target; //Assign to the object you want to rotate
	float angle;
	public float rotation;
	public int selectedWeapon;
	string display;

	public GameObject ak47Symbol;
	public GameObject player;
	public GameObject shotgunSymbol;
	public GameObject shotgun;
	public TextMesh ammoCounter;
	private int ammoDisplayNum;

	public bool weaponsUnlocked;
	public bool pepeUnlocked;

	// public GameObject test;

	// Use this for initialization
	void Start () {
		//selectWeapon();
	}

	void Awake () {
		//selectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

		// possibly necessary ..verify this
		setRotation ();

		// Rotation for the gun to point at mouse
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;
		
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		// weapon switching inputs
		if (Input.GetKeyDown (KeyCode.Alpha1) && weaponsUnlocked && player.gameObject.GetComponent<player1> ().canControl == true) {
			selectedWeapon = 1;
			ammoDisplayNum = 1;
			ak47Symbol.gameObject.SetActive(false);
			shotgunSymbol.gameObject.SetActive(false);
			selectWeapon();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && weaponsUnlocked && player.gameObject.GetComponent<player1> ().canControl == true) {
			selectedWeapon = 2;
			ammoDisplayNum = 2;
			ak47Symbol.gameObject.SetActive(true);
			shotgunSymbol.gameObject.SetActive(false);
			ammoCounter.text = (player.gameObject.GetComponent<player1>().ak47Ammo).ToString();
			selectWeapon();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && weaponsUnlocked && player.gameObject.GetComponent<player1> ().canControl == true) {
			selectedWeapon = 3;
			ammoDisplayNum = 3;
			ak47Symbol.gameObject.SetActive(false);
			shotgunSymbol.gameObject.SetActive(true);
			ammoCounter.text = (player.gameObject.GetComponent<player1>().shotgunAmmo).ToString();
			selectWeapon();
		}
		if (Input.GetKeyDown (KeyCode.Alpha4) && pepeUnlocked && player.gameObject.GetComponent<player1> ().canControl == true) {
			selectedWeapon = 4;
			ammoDisplayNum = 4;
			ak47Symbol.gameObject.SetActive(false);
			shotgunSymbol.gameObject.SetActive(false);
			selectWeapon();
		}

		// display the correct ammo type
		{
			switch (ammoDisplayNum)
			{
			case 1:
				ammoCounter.text = "--";
				break;
			case 2:
				ammoCounter.text = (player.gameObject.GetComponent<player1>().ak47Ammo).ToString();
				break;
			case 3:
				ammoCounter.text = (player.gameObject.GetComponent<player1>().shotgunAmmo).ToString();
				break;
			case 4:
				ammoCounter.text = "--";
				break;
			}
		}


	}

	void selectWeapon(){
		int i = 0;
		foreach (Transform weapon in transform) {
			if (i == selectedWeapon - 1){
				weapon.gameObject.SetActive(true);
			}
			else{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}

	void setRotation(){
		rotation = this.transform.rotation.z;
		// Debug.Log ("Angle - " + rotation);
	}

}
