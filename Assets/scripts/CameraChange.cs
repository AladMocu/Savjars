using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

	public Camera camPlayer1;
	public Camera camPlayer2;
	private int actual;
	public KeyCode change;
	bool salto = true;
	private double jumpSleeper;
	public Animator ChangeAnimation;

	public Transform inP1;

	public Transform inP2;



	// Use this for initialization
	void Start () {
		actual = 0;
		salto = false;
		jumpSleeper = 0;
		ChangeAnimation.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (change)&&!salto) {
			actual = actual == 0 ? 1 : 0;
			salto = true;
			ChangeAnimation.enabled = true;
			ChangeAnimation.Play("CammeraChange", -1, 0f);
		}
		StartCoroutine(Change());


		if (actual == 0) {
			inP1.rotation = Quaternion.LookRotation (camPlayer1.transform.forward);
			inP2.rotation = Quaternion.LookRotation (camPlayer1.transform.forward);
		} else {
			inP1.rotation = Quaternion.LookRotation (camPlayer2.transform.forward);
			inP2.rotation = Quaternion.LookRotation (camPlayer2.transform.forward);
		}
	}
	IEnumerator Change()
	{
		yield return new WaitForSeconds(0.15f);

		camPlayer1.targetDisplay = actual;
		camPlayer2.targetDisplay=actual == 0 ? 1 : 0;
		if (salto) {
			jumpSleeper++;
		}
		if (jumpSleeper == 60) {
			jumpSleeper = 0;
			salto = false;
		}
	}

}
