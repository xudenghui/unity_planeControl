using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_end : MonoBehaviour {

	Transform trans;
	Rigidbody rig;

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}
		
	void Update () {
		Ending();
	}
	void Ending(){
		rig.useGravity = true;
	}
	void OnCollisionEnter(){
		//if(rig.velocity.x > 3)
		//rig.AddForce (-1, 0, 0);
	}
}
