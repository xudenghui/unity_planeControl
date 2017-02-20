using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;


//用于控制主控制面板菜单

public class demo_menu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public static bool pressing = false;        //UI按钮状态
	bool balancing = false;                     //机身前后倾斜状态
	bool turning = false;                       //机身左右倾斜状态
	String selected_name;                       //捕获按钮名称
	Transform trans;
	Rigidbody rig;
	float distance = 0.1f;                      //机身爬升单位

	public void getButton(){
		selected_name = EventSystem.current.currentSelectedGameObject.name;
	}
	void Start () {
		trans = gameObject.transform.parent.parent.parent.GetComponent<Transform> ();
		rig = gameObject.transform.parent.parent.parent.GetComponent<Rigidbody> ();
	}
	void Update () {
		if (gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_up> ().isActiveAndEnabled
		    || gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_down> ().isActiveAndEnabled) {

			balancing = false;
		} 

		if (balancing)
			keepBalance ();
	}

    //按钮按下回调
	public void OnPointerDown(PointerEventData eventData){
		getButton ();
		Debug.Log ("按下按钮"+trans.name);
		pressing = true;
		turning = true;

		switch(selected_name){
		case "bt_up":
			Click_up ();
			balancing = false;
			break;
		case "bt_down":
			Click_down ();
			balancing = false;
			break;
		case "bt_up5":
			balancing = false;
			break;
		case "bt_down5":
			balancing = false;
			break;
		case "bt_left":
			Click_left ();
			turning = true;
			break;
		case "bt_right":
			Click_right ();
			turning = true;
			break;
		}
	}
    //按钮松开回调
	public void OnPointerUp(PointerEventData eventData)
	{
		
		pressing = false;
		turning = false;

		Debug.Log ("松开按钮"+pressing);
		switch(selected_name){
		case "bt_up":
			Click_up ();
			balancing = true;
			break;
		case "bt_down":
			Click_down ();
			balancing = true;
			break;
		case "bt_up5":
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_up5>().enabled = false;
			balancing = true;
			break;
		case "bt_down5":
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_down5>().enabled = false;
			balancing = true;
			break;
		case "bt_left":
			Click_left ();
			turning = true;
			break;
		case "bt_right":
			Click_right ();
			turning = true;
			break;

		}
	}

    //机身前后平衡调整
	public void keepBalance(){
		if (trans.localRotation.eulerAngles.x > 0.1 && trans.localRotation.eulerAngles.x < 20) {
			trans.Rotate (new Vector3 (-1.5f * distance, 0, 0));

		} else if (trans.localRotation.eulerAngles.x < 359.9 && trans.localRotation.eulerAngles.x > 340) {
			trans.Rotate (new Vector3 (1.5f * distance, 0, 0));
		}
	}

	public void Click_start()
	{
		Debug.Log("Click_start");
		//reset ();
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_start>().enabled = true;
	}

	public void Click_end()
	{
		Debug.Log("Click_end");
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_end>().enabled = true;
	}

	public void Click_up()
	{
		Debug.Log("Click_up");
		if(pressing)
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_up>().enabled = true;
		else
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_up>().enabled = false;
	}

	public void Click_down()
	{
		Debug.Log("Click_down");
		if(pressing)
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_down>().enabled = true;
		else
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_down>().enabled = false;
	}

	public void Click_up5()
	{
		Debug.Log("Click_up5");
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_up5>().enabled = true;
	}

	public void Click_down5()
	{
		Debug.Log("Click_down5");
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_down5>().enabled = true;
	}

	public void Click_right()
	{
		Debug.Log("Click_right");
		if (pressing)
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_right>().enabled = true;
		else
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_right>().enabled = false;
		
	}

	public void Click_left()
	{
		Debug.Log("Click_left");
		if (pressing)
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_left> ().enabled = true;
		else
			gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_left> ().enabled = false;
	}

	public void Click_turn_right()
	{
		Debug.Log("Click_turn_right");
	}

	public void Click_turn_left()
	{
		Debug.Log("Click_turn_left");
	}
}