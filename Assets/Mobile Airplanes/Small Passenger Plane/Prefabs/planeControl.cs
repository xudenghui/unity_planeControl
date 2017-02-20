using UnityEngine;
using System.Collections;

public class planeControl : MonoBehaviour {

	Transform trans;
	Rigidbody rd;
	//bool state = true;
	Vector3 ve;
	private float g =  9.81f;
	private float force;
	//得到直升机
	void Start () {
		rd = this.GetComponent<Rigidbody> ();
		rd.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		force = g * (rd.mass);
		if (Input.GetKey (KeyCode.W))
			transform.Translate (new Vector3(0, 0, 0.3f));
		if (Input.GetKey (KeyCode.S))
			transform.Translate (new Vector3(0, 0, -0.3f));
		if (Input.GetKey (KeyCode.A))
			transform.Translate (new Vector3(-0.3f, 0, 0));
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector3(0.3f, 0, 0));
		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate (new Vector3 (0, 0.5f, 0));
		}

		if(Input.GetKey(KeyCode.Q))
			this.transform.Rotate(new Vector3(0, -0.5f, 0));
		if(Input.GetKey(KeyCode.E))
			this.transform.Rotate(new Vector3(0, 0.5f, 0));
		if (Input.GetKeyDown (KeyCode.F)) {
			
			}
		}
	}
