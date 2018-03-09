using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public Animator animator;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("player entry button ");
	}
	void OnTriggerStay(Collider other)
	{
		Debug.Log("player on button ");
	}

}
