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

	public enum Mode
	{
		Hold,
		Activate,
	}
	public Mode mode;
	public Action action;

	public Animator animator;



	private bool state;
    private leaverAnimation leaverAnimation;

	private bool onButton;

    public enum Identifier
	{
		Req_player1,
		Req_player2,
	}
	public Identifier id;

	public ReqsEnabler toChange;


	void Start()
	{
        leaverAnimation = this.GetComponent<leaverAnimation>();
		baseSpot = transform.position;
		if (action == Action.Animation) {
			animator.enabled = false;
		}
		if (kind == Kind.Button) {
			
		}
		if (kind == Kind.Lever) {
			state = !leaverAnimation.p ;
		}

	}
	void Update()
	{
		if (kind == Kind.Button) {
			this.transform.position = baseSpot - new Vector3 (0,massOverButton,0)*0.08f;
		}
        if (kind == Kind.Lever)
        {
            state = !leaverAnimation.p;
        }
	
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			if (kind == Kind.Button) {
				massOverButton += other.GetComponent<Rigidbody> ().mass;
			}
			if (kind == Kind.Lever)
			{
				
				
				if (action == Action.Animation)
				{
					
				
					if (!state) {
						animator.enabled = true;
						if (animator.isInitialized) {
							Debug.Log ("reinding");
							animator.Rebind ();
						}
					} else {
						animator.Play ("Reverse");

					}


				}
				if (action == Action.Bool)
				{
					
					if (id.Equals(Identifier.Req_player1))
					{
						toChange.set1(state);
					}
					else if (id.Equals(Identifier.Req_player2))
					{
						toChange.set2(state);
					}
					
				}
			}
		}


    }
	void OnTriggerStay(Collider other)
	{
		if (kind == Kind.Button) {
			if(massOverButton!=0)Debug.Log("mass over button: "+massOverButton);
			if (massOverButton >= requiredMass) {
				//Case Animator
				if (action == Action.Animation) {
					if (mode == Mode.Activate) {
						animator.enabled = true;
					}
					else if (!onButton) {
						animator.enabled = true;
						if (animator.isInitialized) {
							Debug.Log ("reinding");
							animator.Rebind ();
						}
						onButton = true;
					}
				}
				if (action == Action.Bool) {
					if (id == Identifier.Req_player1) {
						toChange.set1 (true);
					} else if (id == Identifier.Req_player1) {
						toChange.set2 (true);
					}
				}
			} else {
				onButton = false;
			}

		}
		
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals ("Player")) {
			if (kind == Kind.Button) {
				massOverButton -= other.GetComponent<Rigidbody> ().mass;
				if (action == Action.Animation) {
					if(mode==Mode.Hold)
					{
						animator.Play ("Reverse");
					}
				}
			}


		}

	}




}
