#pragma strict

 var explosion : GameObject;
 var canSpawn = true;
 var spawnRate : float = 0.0;
 var waitTime : float;


function Start () {

}

function Update () {
	spawn();

//yield StartCoroutine("spawn");
}

function spawn(){
	yield WaitForSeconds(waitTime);
	
	if(canSpawn){
		Instantiate (explosion, transform.position, transform.rotation);
		canSpawn = false;
		yield WaitForSeconds(spawnRate);
		canSpawn = true;
		}
	
}