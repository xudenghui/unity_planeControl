using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {
	Transform trans;
	Rigidbody rig;
	float speed = 16;
	static bool start_state;

	// Use this for initialization
	void Start () {
		start_state = true;
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (start_state)
			starting ();
		else {
			gameObject.GetComponent<move>().enabled = true;
			gameObject.GetComponent<turn>().enabled = true;
			gameObject.GetComponent<end>().enabled = true;
		}
	}
	void starting(){
		if (rig.velocity.x < speed && rig.velocity.y < speed && rig.velocity.z < speed) {
			rig.AddForce (new Vector3 (0, 0, 20), ForceMode.Force);
		} else {
			speed = 16.3f;
			rig.velocity = new Vector3 (0, 0, speed);
			rig.useGravity = false;
			start_state = false;
			Debug.Log ("starting :state: "+start_state);
		}
	}
}
