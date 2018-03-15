using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqsEnabler : MonoBehaviour {

	// Use this for initialization
	public Animator animator;
    private bool req1;
	private bool req2;

	void Start () {
		animator.enabled = false;
		req1 = false;
		req2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (req1 && req2) {
			animator.enabled = true;
		}
	}
	public void set1(bool p)
	{
		req1 = p;
	}
	public void set2(bool p)
	{
		req2 = p;
	}

}
