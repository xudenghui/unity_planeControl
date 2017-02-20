using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_up : MonoBehaviour {

	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;   //机身上升单位
	float height = 0;        //已下降高度

	void Start () {
		trans = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody> ();
	}
		
	void Update () {
        //重置已上升高度，在机身平衡后允许飞机持续上升
        if (trans.localRotation.eulerAngles.x <= 0.1f || trans.localRotation.eulerAngles.x >= 359.9f)
			height = 0;
		moveUp ();
	}
    
    //仅控制上升期仰角峰值
	public void moveUp(){
		
		if (height < 5) {
			transform.Translate (new Vector3 (0, distance, 0));
			trans.Rotate (new Vector3 (-3*distance, 0, 0));
			height = height + 0.1f;
			Debug.Log ("飞机高度调整中 ："+height);
		} else {
			transform.Translate (new Vector3 (0, distance, 0));
		}
	}
}
