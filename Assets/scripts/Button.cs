using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {


	public Animator animator;
	public float massOverButton=0;
	private Vector3 baseSpot;

	void Start()
	{
		animator.enabled = false;
		baseSpot = transform.position;
	}
	void Update()
	{
		this.transform.position = baseSpot - new Vector3 (0,massOverButton,0)*0.08f;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			massOverButton += other.GetComponent<Rigidbody> ().mass;
		}
	
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
		if (other.tag.Equals ("Player")) {
			massOverButton -= other.GetComponent<Rigidbody> ().mass;
		}
	
	}

}
