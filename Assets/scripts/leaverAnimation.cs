using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaverAnimation : MonoBehaviour {

	public Animator baseAnimation;
	// Use this for initialization
	void Start () {
		baseAnimation.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		baseAnimation.enabled = true;
	}
}
