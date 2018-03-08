using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

	public Camera camPlayer1;
	public Camera camPlater2;
	private int actual;
	public KeyCode change;
	bool salto = true;
	private double jumpSleeper;
	// Use this for initialization
	void Start () {
		actual = 0;
		salto = false;
		jumpSleeper = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (change)&&!salto) {
			actual = actual == 0 ? 1 : 0;
			salto = true;
		}
		camPlayer1.targetDisplay = actual;
		camPlater2.targetDisplay=actual == 0 ? 1 : 0;
		if (salto) {
			jumpSleeper++;
		}
		if (jumpSleeper == 60) {
			jumpSleeper = 0;
			salto = false;
		}
	}
}
