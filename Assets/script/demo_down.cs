using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_down : MonoBehaviour {

	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;  //机身下降单位
    float hight = 0;        //已下降高度

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}

	void Update () {
        //重置已下降高度，在机身平衡后允许飞机持续下降
		if (trans.localRotation.eulerAngles.x <= 0.1f || trans.localRotation.eulerAngles.x >= 359.9f)
			hight = 0;
		moveDown ();
	}

    //仅控制下降期俯角峰值
    void moveDown(){
		
		if (hight < 5) {
			trans.Translate (new Vector3 (0, -1 * distance, 0));
			trans.Rotate (new Vector3 (3*distance, 0, 0));
			hight = hight + 0.1f;
		} else {
			trans.Translate (new Vector3 (0, -1 * distance, 0));
			Debug.Log ("飞机高度调整完毕");
		}
	}
}
