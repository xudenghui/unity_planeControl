using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour {
	Transform trans;
	Rigidbody rig;
	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey (KeyCode.D)))
			Ending();
	}
	void Ending(){
		rig.useGravity = true;
	}
}
