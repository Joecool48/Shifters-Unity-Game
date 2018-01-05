using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressAnimation : MonoBehaviour {
	private GameObject Star1, Star2, Star3;
	public float progress = 0.0f;
	private float width;
	private RectTransform transform;
	private RectTransform frame;
	public void ChangeProgress (float NewProgress) {
		//Setting the stars active based on the amount of progress.
		transform.localScale = new Vector2 (NewProgress, transform.localScale.y);
		progress = NewProgress;
		if (progress > (1f / 3f)) {
			Star1.SetActive (true);
		} else {
			Star1.SetActive (false);
		}
		if (progress > (2f / 3f)) {
			Star2.SetActive (true);
		} else {
			Star2.SetActive (false);
		}
		if (progress == 1f) {
			Star3.SetActive (true);
		} else {
			Star3.SetActive (false);
		}
	}

	void Start () {
		transform = GetComponent<RectTransform> ();
		width = transform.rect.width;
		frame = GameObject.Find ("Frame").GetComponent<RectTransform> ();
		Star1 = GameObject.Find ("Star1");
		Star1.SetActive (false);
		Star2 = GameObject.Find ("Star2");
		Star2.SetActive (false);
		Star3 = GameObject.Find ("Star3");
		Star3.SetActive (false);
	}
	void Update () {
	}
}
