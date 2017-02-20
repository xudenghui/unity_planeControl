using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {
	
	public void Click_start()
	{
		Debug.Log("Click_start");
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<demo_start>().enabled = true;
		//gameObject.transform.parent.parent.parent.gameObject.GetComponent<start>().enabled = true;

		gameObject.transform.parent.parent.parent.gameObject.GetComponent<end>().enabled = false;

 	}
	public void Click_drop()
	{
		Debug.Log("Click_drop");
		gameObject.transform.parent.parent.parent.gameObject.GetComponent<end>().enabled = true;

		//gameObject.transform.parent.parent.parent.gameObject.GetComponent<start>().enabled = false;
	}
	public void Click_up()
	{
		Debug.Log("Click_up");
		//gameObject.transform.parent.parent.parent.gameObject.GetComponent<start>().enabled = true;
	}
	public void Click_down()
	{
		Debug.Log("Click_start");
		//gameObject.transform.parent.parent.parent.gameObject.GetComponent<start>().enabled = true;
	}
}
