using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics_Movement : MonoBehaviour {

	public KeyCode jump;
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode rigth;

	public float step;
	private double jumpSleeper;

	private bool salto;

	private float jumpH;

	public float aquaMass;
	// Use this for initialization
	void Start () {
		salto = false;
		jumpSleeper = 0;
		jumpH = 500;
		aquaMass = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (jump)&&!salto) {
			GetComponent<Rigidbody> ().AddForce (new Vector3(0,jumpH,0));
			salto = true;

		}
		if (Input.GetKey (forward)) {
			transform.Translate (0,0,-step);
		}
		if (Input.GetKey (back)) {
			transform.Translate (0,0,step);
		}
		if (Input.GetKey (left)) {
			transform.Translate (step,0,0);
		}
		if (Input.GetKey (rigth)) {
			transform.Translate (-step,0,0);
		}
		if (salto) {
			jumpSleeper++;
		}
		if (jumpSleeper == 60) {
			jumpSleeper = 0;
			salto = false;
		}

		this.GetComponent<Rigidbody> ().mass =aquaMass;

	}
}
