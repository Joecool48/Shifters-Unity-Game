using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAnimation : MonoBehaviour {
	private GameObject hole;
	public float HoleSpinSpeed;
	// Use this for initialization
	void Start () {
		hole = GameObject.Find ("Hole");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hole.transform.Rotate (new Vector3 (0, 0, HoleSpinSpeed));
	}
	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Works!");
	}
}
