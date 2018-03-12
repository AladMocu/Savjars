using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaManagement : MonoBehaviour {

	public SimpleHealthBar aquaOnPlayer;
	// Use this for initialization
	public float aqua;
	void Start () {
		aqua = 50f;
		aquaOnPlayer.UpdateBar (aqua, 100f);
	}
	
	// Update is called once per frame
	void Update () {
		aquaOnPlayer.UpdateBar (aqua, 100f);
	}
}
