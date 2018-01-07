using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundRectSpinner : MonoBehaviour {
	public float RotateSpeed;
	private GameObject RoundRectSpin;
	public bool Rotating;
	private SpriteRenderer HorizontalSprite;
	private SpriteRenderer VerticalSprite;
	private GameObject Horizontal;
	private GameObject Vertical;
	public Color color;
	// Use this for initialization
	void Start () {
		RoundRectSpin = GameObject.Find ("Rounded Rectangle Spinner");
		Horizontal = GameObject.Find ("Horizontal Rounded Rectangle");
		Vertical = GameObject.Find ("Vertical Rounded Rectangle");
		HorizontalSprite = Horizontal.GetComponent<SpriteRenderer> ();
		VerticalSprite = Vertical.GetComponent<SpriteRenderer> ();
		RotateSpeed = 1;
		Rotating = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Rotating) {
			RoundRectSpin.transform.Rotate (new Vector3 (0f, 0f, RotateSpeed));
		}
		ChangeColor (color);
		ScaleRect ();
	}
	void ChangeColor (Color color) {
		HorizontalSprite.color = color;
		VerticalSprite.color = color;
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