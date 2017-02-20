using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_left : MonoBehaviour {

	Transform trans;
	Rigidbody rig;
	Transform tranLeft;				//左副翼
	Transform tranRight;			//右副翼
	float turn_angle = 0.3f;    //机身旋转角度
    float angular = 0.1f;       //副翼旋转角度

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();

		tranLeft = GameObject.Find ("ControlSurface_L").GetComponent<Transform> ();
		tranRight = GameObject.Find("ControlSurface_R").GetComponent<Transform> ();

	}

	void Update () {
		turning ();
	}

    //机身及副翼联动旋转
    void turning(){
		//Debug.Log ("current_angle :"+current_angle);

			trans.Rotate (new Vector3 (0, -1 * turn_angle, 0));

			if(trans.localRotation.eulerAngles.z < 10 || trans.localRotation.eulerAngles.z > 350)
				trans.Rotate (new Vector3 (0, 0, 0.3f*turn_angle));

			//Debug.Log ("此时的右副翼角度为：" + tranRight.localRotation.eulerAngles.x);
			if (tranRight.localRotation.eulerAngles.x >= 340 || tranRight.localRotation.eulerAngles.x <= 20) {
				tranLeft.Rotate (new Vector3 (angular, 0, 0));
				tranRight.Rotate (new Vector3 (-1 * angular, 0, 0));
			}

        //锁定X轴
        trans.rotation = Quaternion.Euler (0, trans.localRotation.eulerAngles.y, trans.localRotation.eulerAngles.z);

			flapBalance ();
	}

    //副翼调整平衡
    void flapBalance(){
		//Debug.Log ("进入副翼自动调整状态"+tranRight.localRotation.eulerAngles.x);
		if (tranRight.localRotation.eulerAngles.x <= 359.8 || tranRight.localRotation.eulerAngles.x >= 0.3) {
			//Debug.Log ("开始判断副翼位置");
			if (tranRight.localRotation.eulerAngles.x >= 339 && tranRight.localRotation.eulerAngles.x <= 359) {
				//Debug.Log ("右降左升");

				tranLeft.Rotate (-1 * angular, 0, 0);
				tranRight.Rotate (angular, 0, 0);

			} else if (tranRight.localRotation.eulerAngles.x <= 21 && tranRight.localRotation.eulerAngles.x >= 1) {
				//Debug.Log ("左降右升");

				tranLeft.Rotate (new Vector3 (angular, 0, 0));
				tranRight.Rotate (new Vector3 (-1 * angular, 0, 0));
			}
		}
		if (trans.localRotation.eulerAngles.z < 359 || trans.localRotation.eulerAngles.z > 1) {
			//Debug.Log ("开始判断机身倾斜状态"+trans.localRotation.eulerAngles.z);
			if (trans.localRotation.eulerAngles.z >= 339 && trans.localRotation.eulerAngles.z < 359) {
				//Debug.Log ("右降左升");

				trans.Rotate (new Vector3 (0, 0, 0.3f * turn_angle));
			} else if (trans.localRotation.eulerAngles.z > 1 && trans.localRotation.eulerAngles.z <= 21) {
				//Debug.Log ("左降右升");

				trans.Rotate (new Vector3 (0, 0, -0.3f * turn_angle));
			}
		} else {
            //锁定X,Z轴
            trans.rotation = Quaternion.Euler (0, trans.localRotation.eulerAngles.y, 0);
		}
	}
}
