using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_down5 : MonoBehaviour {

	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;
	float hight = 0;
	bool moveDown_state = true;

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}


	void Update () {
		if (moveDown_state) {
			moveDown ();
		} else {
			hight = 0;
			moveDown_state = true;
			gameObject.GetComponent<demo_down5> ().enabled = false;
		}
	}

    //同时控制飞机下降高度及俯角峰值
	void moveDown(){
		if (hight < 5) {
			trans.Translate (new Vector3 (0, -1 * distance, 0));
			trans.Rotate (new Vector3 (3*distance, 0, 0));
			hight = hight + 0.1f;
		} else {
			Debug.Log ("飞机高度调整完毕");
			hight = 0;
			rig.freezeRotation = true;
			moveDown_state = false;
		}
	}
}
