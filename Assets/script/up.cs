using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
	Vector3 speed;
	float up_angle = -0.15f;
	float down_angle = 0.12f;
	Transform up_trans;
	Transform tail;
	Rigidbody up_rig;
	bool up_state = true;

	// Use this for initialization
	void Start () {
		//Debug.Log ("进入up函数");
		up_trans = GetComponent<Transform> ();
		tail = transform.FindChild ("MainControlTail");
		up_rig = GetComponent<Rigidbody> ();
		speed = up_rig.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (up_state) {
			uping ();
			if(!up_state && !judgeBalanceAngle())
				up_rig.velocity = new Vector3 (0, 0, 0);
		}
		else if(transform.position.y>0.5f){
			//Debug.Log ("已经完成平衡调整");
			transform.Translate (new Vector3(0, 0, 0.3f));
		
		}
		tail.rotation = Quaternion.Euler (2*up_trans.eulerAngles.x, up_trans.eulerAngles.y, 0);
		//Debug.Log ("tail.rotation : "+tail.eulerAngles);
	}
	void uping(){
		if (up_rig.velocity.x >= 16 || up_rig.velocity.y > 16 || up_rig.velocity.z > 16) {

			if (up_trans.position.y < 25) {
				//Debug.Log ("up_trans.rotation:   "+up_trans.localRotation.eulerAngles);
				if (judgeUpAngle ()) {
					//Debug.Log ("正在调整高度  " + up_trans.position.y);
					transform.Rotate (new Vector3 (up_angle, 0, 0));
				}
				transform.Translate (new Vector3 (0, 0.1f, 0));
			}
			if (up_trans.position.y >= 25) {
				//Debug.Log ("即将进入平衡调整");
				if (judgeBalanceAngle ()) {
					//Debug.Log ("进入平衡调整最后阶段");
					transform.Rotate (new Vector3 (down_angle, 0, 0));
				} else {
					up_state = false;
				}
			}
		} 
	}
	bool judgeUpAngle(){
		//Debug.Log ("进入judgeUpAngle():"+getAbs (up_trans.localRotation.eulerAngles.x));
			if (getAbs (up_trans.localRotation.eulerAngles.x) < 15 && getAbs (up_trans.localRotation.eulerAngles.y) < 15 && getAbs (up_trans.localRotation.eulerAngles.z) < 15)
				return true;
			else
				return false;
	}
	bool judgeBalanceAngle(){
		//Debug.Log ("进行平衡参数判断"+getAbs (up_trans.localRotation.eulerAngles.x));
		if (getAbs (up_trans.localRotation.eulerAngles.x) >= 0.5f || getAbs (up_trans.localRotation.eulerAngles.z) >= 0.5f)
			return true;
		else
			return false;
	}
	float getAbs(float angle){
		if (angle > 180)
			return Mathf.Abs (angle - 360);
		else
			return Mathf.Abs (angle);
	}
}
