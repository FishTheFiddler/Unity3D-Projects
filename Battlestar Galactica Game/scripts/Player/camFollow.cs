using UnityEngine;
using System.Collections;

public class camFollow : MonoBehaviour {
	
	// What shall we look at?
	public Transform target;
	
	void Update () {
		
		// Look at target transform.
		this.transform.LookAt (target.position);
		
		// Set position to 10 units behind target.
		this.transform.position = target.position + 
			(this.transform.forward * -7f);
		
	}
}