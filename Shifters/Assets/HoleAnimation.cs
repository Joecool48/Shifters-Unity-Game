using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAnimation : MonoBehaviour {
	private GameObject hole;
	public float HoleSpinSpeed;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		hole = GameObject.Find ("Hole");
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hole.transform.Rotate (new Vector3 (0, 0, HoleSpinSpeed));
	}
	void Update () {
		ScaleHole ();
	}
	void OnTriggerEnter2D (Collider2D other) {
		Camera.main.GetComponent<GameManager> ().GameEnd ();
	}
	void ScaleHole () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		Sprite s = spriteRenderer.sprite;
		float unitWidth = s.textureRect.width / s.pixelsPerUnit;
		float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		spriteRenderer.transform.localScale = new Vector3(width / unitWidth / 9, width / unitWidth / 9, 0);
	}
}
