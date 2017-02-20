using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//飞机助跑及起飞平衡控制

public class demo_start : MonoBehaviour {
	Transform trans;
	Rigidbody rig;
	float speed = 16;           //速度临界值
	static bool start_state;    //助跑判定
	Animator am;
	AudioSource au;

	Vector3 up_speed;
	float up_angle = -0.15f;    //仰调速率
	float down_angle = 0.12f;   //俯调速率
	Transform up_trans;
	Transform tail;
	Rigidbody up_rig;
	bool up_state = true;       //平衡判定

	void Start () {
		am = GameObject.Find ("Cessna_Propeller").GetComponent<Animator> ();//动画源
		am.enabled = true;

		au = gameObject.GetComponent<AudioSource>();                        //音频源
		au.enabled = true;
		start_state = true;
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();

		up_trans = GetComponent<Transform> ();
		tail = transform.FindChild ("MainControlTail");
		up_rig = GetComponent<Rigidbody> ();
		up_speed = up_rig.velocity;
	}
	
	void Update () {
		if (start_state)
			starting ();

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

    //助跑阶段
	void starting(){
		if (rig.velocity.x < speed && rig.velocity.y < speed && rig.velocity.z < speed) {
			rig.AddForce (new Vector3 (0, 0, 20), ForceMode.Force);
		} else {
			speed = 16.3f;
			rig.velocity = new Vector3 (0, 0, speed);
			rig.useGravity = false;
			start_state = false;
			//Debug.Log ("starting :state: "+start_state);
		}
	}

    //平衡阶段
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

    //判定助跑阶段飞机仰角是否达到峰值
	bool judgeUpAngle(){
		//Debug.Log ("进入judgeUpAngle():"+getAbs (up_trans.localRotation.eulerAngles.x));
		if (getAbs (up_trans.localRotation.eulerAngles.x) < 15 && getAbs (up_trans.localRotation.eulerAngles.y) < 15 && getAbs (up_trans.localRotation.eulerAngles.z) < 15)
			return true;
		else
			return false;
	}

    //判断机身是否平衡
	bool judgeBalanceAngle(){
		//Debug.Log ("进行平衡参数判断"+getAbs (up_trans.localRotation.eulerAngles.x));
		if (getAbs (up_trans.localRotation.eulerAngles.x) >= 0.5f || getAbs (up_trans.localRotation.eulerAngles.z) >= 0.5f)
			return true;
		else
			return false;
	}

    //获取机身倾角（0至180度）
	float getAbs(float angle){
		if (angle > 180)
			return Mathf.Abs (angle - 360);
		else
			return Mathf.Abs (angle);
	}
}

