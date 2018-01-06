using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public float touchCharge = 1;
	public string MenuLoaded;
	public float CameraSpeed = 1;
	protected GameObject player;
	protected Camera MainCamera;
	protected GameObject GameEndScreen;
	//Initially don't move at all
	protected int MovementType = -1;
	protected enum MovementOptions {SimpleForwardMovement = 0,SimpleBackwardMovement = 1,SimpleRightMovement = 2,SimpleLeftMovement = 3,RandomMovement = 4};
	public bool gameRunning = true;
	// Use this for initialization
	void Start () {
		init ();
	}
	protected void init () {
		player = GameObject.Find ("Player");
		MainCamera = Camera.main;
		GameEndScreen = GameObject.Find ("GameEnd");
		GameEndScreen.SetActive (false);
	}
	public void GameEnd () {
		gameRunning = false;
		player.SetActive (false);
		GameEndScreen.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		ChooseCameraMovement ();
	}
	protected void ChooseCameraMovement () {
		switch (MovementType) {
		case (int)MovementOptions.SimpleForwardMovement:
			SimpleForwardMovement ();
			break;
		case (int)MovementOptions.SimpleBackwardMovement:
			SimpleBackwardMovement ();
			break;
		case (int)MovementOptions.SimpleRightMovement:
			SimpleRightMovement ();
			break;
		case (int)MovementOptions.SimpleLeftMovement:
			SimpleLeftMovement ();
			break;
		case (int)MovementOptions.RandomMovement:
			RandomMovement ();
			break;
		}
	}
	public void OnMenuClicked () {
		SceneManager.LoadScene (MenuLoaded);
	}
	protected void SimpleForwardMovement () {
		transform.position += new Vector3 (0, CameraSpeed, 0);
	}
	protected void SimpleBackwardMovement () {
		transform.position += new Vector3 (0, -CameraSpeed, 0);
	}
	protected void SimpleRightMovement () {
		transform.position += new Vector3 (CameraSpeed, 0, 0);
	}
	protected void SimpleLeftMovement () {
		transform.position += new Vector3 (-CameraSpeed, 0, 0);
	}
	protected void RandomMovement () {
		
	}
}
