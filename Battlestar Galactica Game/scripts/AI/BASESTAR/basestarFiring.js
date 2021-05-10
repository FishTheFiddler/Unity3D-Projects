#pragma strict

 var missiles : GameObject;
 var canSpawn = true;
 var spawnRate : float = 0.0;
 var waitTime : float;


function Start () {

}

function Update () {
	spawn();
}

function spawn(){
	yield WaitForSeconds(waitTime);
	
	if(canSpawn){
		Instantiate (missiles, transform.position, transform.rotation);
		canSpawn = false;
		yield WaitForSeconds(spawnRate);
		canSpawn = true;
		}
	
}