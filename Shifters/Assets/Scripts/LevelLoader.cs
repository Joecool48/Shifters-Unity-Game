using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	private Button button;
	private Text text;
	// Use this for initialization
	void Start () {
		button = (Button) transform.Find ("Button").GetComponent<Button> ();
		text = (Text)transform.Find ("Button/Text").GetComponent<Text> ();;
		button.onClick.AddListener(delegate { OnClick (name); });
	}
	void OnClick (string name) {
		SceneManager.LoadScene (name);
	}
	// Update is called once per frame
	void Update () {
	}
}
