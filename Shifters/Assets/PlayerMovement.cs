using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerCharge;
	private Rigidbody2D rgb2d;
	private Touch[] myTouches;
	private GameManager gameManager;
	public bool gameRunning = true;
	private GameObject player;
	private Camera cam;
	private GameObject gameEnd;
	private SpriteRenderer spriteRenderer;
	void ScalePlayer () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		Sprite s = spriteRenderer.sprite;
		float unitWidth = s.textureRect.width / s.pixelsPerUnit;
		float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		spriteRenderer.transform.localScale = new Vector3(width / unitWidth / 9, width / unitWidth / 9, 0);
	}
	void OnGUI () {
		cam = Camera.main;
	}
	//Detects if the player has lost or not
	void OnBecameInvisible () {
		gameRunning = false;
		player.SetActive (false);
		gameEnd.SetActive (true);
	}
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		gameEnd = GameObject.Find ("GameEnd");
		gameEnd.SetActive (false);
		gameManager = GetComponent<GameManager> ();
		player = GameObject.Find("Player");
		rgb2d = GetComponent<Rigidbody2D> ();
		if (rgb2d == null) {
			player.GetComponent<Rigidbody2D> ();
		}
		ScalePlayer ();
	}
	void OnAwake() {
	}
	void Update() {
		myTouches = Input.touches;
	}
	// Update is called once per frame
	void FixedUpdate() {
		if (rgb2d == null) {
			print ("Why is RGB2D null?");
		}
		ScalePlayer ();
		if (gameRunning) {
			if (myTouches != null && myTouches.Length <= 2) {
				for (int i = 0; i < myTouches.Length; i++) {
					Vector3 touchVector = cam.ScreenToWorldPoint((new Vector3 (myTouches[i].position.x, myTouches[i].position.y, 0)));
					Vector2 touch = new Vector2 (touchVector.x, touchVector.y);
					Vector2 myVector = rgb2d.position - touch;
					Vector2 direction = myVector.normalized;
					float magnitude = myVector.magnitude;
					//Replace with gameManager.touchCharge later.
					float scale = ((playerCharge * 1) / (magnitude * magnitude));
					Vector2 playerForce = new Vector2 (direction.x * scale, direction.y * scale);
					rgb2d.AddForce (playerForce);
				}
			}
		}
	}
}
