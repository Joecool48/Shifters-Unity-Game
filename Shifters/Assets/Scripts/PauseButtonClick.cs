using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonClick : MonoBehaviour {
	private Image image;
	private Button button;
	private Color[] colors;
	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		image = GetComponent<Image> ();
		button.onClick.AddListener(delegate { OnClick (); });
		colors = new Color[5];
		colors [0] = Color.red;
		colors [1] = Color.blue;
		colors [2] = Color.green;
		colors [3] = Color.magenta;
		colors [4] = Color.cyan;
		int random = Random.Range (0, colors.Length);
		image.color = colors [random];
	}

	// Update is called once per frame
	void Update () {
	}
	public void OnClick () {
		print ("Lol");
		int random = Random.Range (0, colors.Length);
		image.color = colors [random];
	}
}
