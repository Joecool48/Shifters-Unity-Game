using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : GameManager {
	private GameObject player;
	// Use this for initialization
	void Start () {
		init ();
		player = GameObject.Find ("Player");

		MovementType = (int) MovementOptions.SimpleForwardMovement;
	}
	
	// Update is called once per frame
	void Update () {
		SimpleForwardMovement ();
	}
}
