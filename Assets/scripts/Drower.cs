using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drower : MonoBehaviour {

	public AquaManagement thisPlayer;

	public AquaManagement otherPlayer;

	public Basics_Movement playerMoves;
	// Use this for initialization
	void Start () {
		

	}
	void OnTriggerStay(Collider other)
	{	if (other.tag.Equals ("Player")) {
			if (thisPlayer.aqua < 100 && otherPlayer.aqua > 0) {
				thisPlayer.aqua += 0.5f;
				otherPlayer.aqua -= 0.5f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		playerMoves.aquaMass = thisPlayer.aqua/100 +1;
		
	}
}
