﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaverAnimation : MonoBehaviour {

	public Animator baseAnimation;
	public  bool p;
	// Use this for initialization
	void Start () {
		baseAnimation.enabled = false;
		p=true ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
        
		if (other.tag.Equals ("Player")) {
	
			if (p) {
			//	baseAnimation.Play ("onLever", -1, 0f);
				baseAnimation.enabled = true;
				if (baseAnimation.isInitialized) {
					Debug.Log ("reinding");
					baseAnimation.Rebind ();
				}

			} else {
				baseAnimation.Play ("OnleverReverse", -1, 0f);
			}

			p=!p;
		}
	}
}
