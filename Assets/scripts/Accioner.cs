using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accioner : MonoBehaviour {



	private float massOverButton=0;
	private Vector3 baseSpot;

	/**
	 * Mass to activate the button
	 * **/
	public float requiredMass;

	public enum Kind{
		Button,
		Lever,
	}
	public Kind kind;


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
		if (kind == Kind.Button) {
			requiredMass = 2;
		}
	}
	void Update()
	{
		if (kind == Kind.Button) {
			this.transform.position = baseSpot - new Vector3 (0,massOverButton,0)*0.08f;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			if (kind == Kind.Button) {
				massOverButton += other.GetComponent<Rigidbody> ().mass;
			}
		}

	}
	void OnTriggerStay(Collider other)
	{
		if (kind == Kind.Button) {
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
		if (kind == Kind.Lever) {
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
			if (kind == Kind.Button) {
				massOverButton -= other.GetComponent<Rigidbody> ().mass;
			}
		}

	}

}
