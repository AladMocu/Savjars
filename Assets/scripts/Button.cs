using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;

	public Animator animator;
	protected float massOverButton=0;

	void Start()
	{
		animator.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		massOverButton+=other.GetComponent<Rigidbody> ().mass;
	}
	void OnTriggerStay(Collider other)
	{
		Debug.Log("mass over button: "+massOverButton);
		if (massOverButton >= 2) {
			animator.enabled = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		massOverButton-=other.GetComponent<Rigidbody> ().mass;
	}

}
