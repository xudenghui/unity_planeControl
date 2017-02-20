using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;
	float hight = 0;
	bool moveUp_state = false;
	bool moveDown_state = false;
	bool turn_over = false;
	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			moveUp_state = true;
			rig.freezeRotation = false;
			Debug.Log ("按下W键"+moveUp_state);
		}
		if (moveUp_state) {
			moveUp ();
		} else {
			if(turn_over)
				turn_over = keepBalance ();
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			moveDown_state = true;
			rig.freezeRotation = false;
			Debug.Log ("按下S键"+moveDown_state);
		}
		if (moveDown_state) {
			moveDown ();
		} else {
			if(turn_over)
				turn_over = keepBalance ();
		}
		
	}
	void moveUp(){
		//Debug.Log ("进入高度调整");
		if (hight < 5) {
			transform.Translate (new Vector3 (0, distance, 0));
			trans.Rotate (new Vector3 (-3*distance, 0, 0));
			turn_over = true;
			hight = hight + 0.1f;
			Debug.Log ("飞机高度调整中 ："+hight);
		} else {
			Debug.Log ("飞机高度调整完毕"+trans.localRotation.eulerAngles.x);
			hight = 0;
			rig.freezeRotation = true;
			moveUp_state = false;
			turn_over = true;
		}
	}
	void moveDown(){
		if (hight > -5) {
			trans.Translate (new Vector3 (0, -1 * distance, 0));
			trans.Rotate (new Vector3 (3*distance, 0, 0));
			turn_over = true;
			hight -= distance;
		} else {
			Debug.Log ("飞机高度调整完毕");
			hight = 0;
			rig.freezeRotation = true;
			moveDown_state = false;
			turn_over = true;
		}
	}
	public bool keepBalance(){
		if (trans.localRotation.eulerAngles.x > 0.1 && trans.localRotation.eulerAngles.x < 20) {
			trans.Rotate (new Vector3 (-1.5f * distance, 0, 0));
			return true;
		} else if (trans.localRotation.eulerAngles.x < 359.9 && trans.localRotation.eulerAngles.x > 340) {
			trans.Rotate (new Vector3 (1.5f * distance, 0, 0));
			return true;
		}
		else
			return false;
	}
}
