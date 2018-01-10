using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectSpinner : MonoBehaviour {
	public float RotateSpeed;
	private GameObject RectSpin;
	public bool Rotating;
	private SpriteRenderer HorizontalSprite;
	private SpriteRenderer VerticalSprite;
	private GameObject Horizontal;
	private GameObject Vertical;
	public Color32 color;
	// Use this for initialization
	void Start () {
		RectSpin = GameObject.Find ("Rectangular Spinner");
		Horizontal = GameObject.Find ("Horizontal Rectangle");
		Vertical = GameObject.Find ("Vertical Rectangle");
		HorizontalSprite = Horizontal.GetComponent<SpriteRenderer> ();
		VerticalSprite = Vertical.GetComponent<SpriteRenderer> ();
		Rotating = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ScaleRect ();
		if (Rotating) {
			RectSpin.transform.Rotate (new Vector3 (0f, 0f, RotateSpeed));
		}
		ChangeColor (color);
	}
	void ChangeColor (Color32 color) {
		foreach(SpriteRenderer c in GetComponents<SpriteRenderer> ()) {
			c.material.color = color;
		}
	}
	void Scale (Vector3 size) {
		HorizontalSprite.transform.localScale += size;
		VerticalSprite.transform.localScale += size;
	}
	void HorizontalScale (Vector3 size) {
		HorizontalSprite.transform.localScale += size;
	}
	void VerticalScale (Vector3 size) {
		VerticalSprite.transform.localScale += size;
	}
	void ScaleRect () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		float unitWidth = HorizontalSprite.sprite.textureRect.width / HorizontalSprite.sprite.pixelsPerUnit;
		float unitHeight = VerticalSprite.sprite.textureRect.height / VerticalSprite.sprite.pixelsPerUnit;

		transform.localScale = new Vector3(width / unitWidth / 2, width / unitWidth / 2, 0);
	}
}
