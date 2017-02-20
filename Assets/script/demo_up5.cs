using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_up5 : MonoBehaviour {

	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;
	float hight = 0;
	bool moveUp_state = true;

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (moveUp_state) {
			moveUp ();
		} else {
			hight = 0;
			moveUp_state = true;
			gameObject.GetComponent<demo_up5> ().enabled = false;
		}
	}

    //同时控制飞机上升高度及仰角峰值
	void moveUp(){
		//Debug.Log ("进入高度调整");
		if (hight < 5) {
			transform.Translate (new Vector3 (0, distance, 0));
			trans.Rotate (new Vector3 (-3*distance, 0, 0));
			hight = hight + 0.1f;
			Debug.Log ("飞机高度调整中 ："+hight);
		} else {
			Debug.Log ("飞机高度调整完毕"+trans.localRotation.eulerAngles.x);
			hight = 0;
			rig.freezeRotation = true;
			moveUp_state = false;
		}
	}
}
