using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIHandler : MonoBehaviour {
	public string PlaySceneLoaded;
	public string LevelSelectSceneLoaded;
	public string SettingsSceneLoaded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClickPlay() {
		SceneManager.LoadScene (PlaySceneLoaded);
	}
	public void OnClickLevel_Select() {
		SceneManager.LoadScene (LevelSelectSceneLoaded);
	}
	public void OnClickSettings() {
		SceneManager.LoadScene (SettingsSceneLoaded);
	}
	public void OnClickQuit () {
		Application.Quit();
	}
}
