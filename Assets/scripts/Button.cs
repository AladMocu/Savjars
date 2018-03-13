using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour {


	private float massOverButton=0;
	private Vector3 baseSpot;

	/**
	 * Mass to activate the button
	 * **/
	public float requiredMass;

	public enum Action{
		Animation,
		Bool,
	}
	public Action action;

	public Animator animator;




	public enum Identifier
	{
		Req_player1,
		Req_player2,
	}
	public Identifier id;

	public ReqsEnabler toChange;


	void Start()
	{
		baseSpot = transform.position;
		if (action == Action.Animation) {
			animator.enabled = false;
		}
		requiredMass = 2;
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
		if (massOverButton >= requiredMass) {
			//Case Animator
			if (action == Action.Animation) {
				animator.enabled = true;
			}
			if (action == Action.Bool) {
				if (id == Identifier.Req_player1) {
					toChange.set1 (true);
				} else {
					toChange.set2 (true);
				}
			}


		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			massOverButton -= other.GetComponent<Rigidbody> ().mass;
		}
	
	}

}
