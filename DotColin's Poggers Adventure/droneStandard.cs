using UnityEngine;
using System.Collections;

public class droneStandard : MonoBehaviour {

	private int health;

	private float speed = 3f;
	public Transform target;
	public GameObject self;
	public GameObject explosion;
	private int explosionNumber;
	public AudioClip explosionSound;
	public AudioClip explosionSound2;
	public AudioClip explosionSound3;
	public AudioClip explosionSound4;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
	}

	void Awake () {
		//target.transform.position = new Vector3 ();
		health = 8;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 vertical = new Vector2(0,-2);
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
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
				case "pepeBullet":
					health -= 3;
					break;
				case "Player":
					health -= 8;
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
