using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaverAnimation : MonoBehaviour {

	public Animator baseAnimation;
    private int dir;
	// Use this for initialization
	void Start () {
		baseAnimation.enabled = false;
        dir =1 ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
        
		if (other.tag.Equals ("Player")) {
        
			Debug.Log ("dir is: " + dir);

			baseAnimation.speed = dir;
			baseAnimation.enabled = true;
			baseAnimation.Play ("onLever", -1, 0f);
			dir *= -1;
		}
	}
}
