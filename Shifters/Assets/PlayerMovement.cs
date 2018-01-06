using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerCharge;
	private Rigidbody2D rgb2d;
	private Touch[] myTouches;
	private GameManager gameManager;
	private GameObject player;
	private GameObject GameEndScreen;
	private SpriteRenderer spriteRenderer;
	void ScalePlayer () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		Sprite s = spriteRenderer.sprite;
		float unitWidth = s.textureRect.width / s.pixelsPerUnit;
		float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		spriteRenderer.transform.localScale = new Vector3(width / unitWidth / 9, width / unitWidth / 9, 0);
	}
	//Detects if the player has lost or not
	void OnBecameInvisible () {
		Camera.main.GetComponent<GameManager> ().GameEnd ();
	}
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		GameEndScreen = GameObject.Find ("GameEnd");
		gameManager = GetComponent<GameManager> ();
		player = GameObject.Find("Player");
		rgb2d = GetComponent<Rigidbody2D> ();
		gameManager = Camera.main.GetComponent<GameManager> ();
	}
	void Scale () {
		float depth = gameObject.transform.lossyScale.z;
		float width = gameObject.transform.lossyScale.x;
		float height = gameObject.transform.lossyScale.y;

		Vector3 lowerLeftPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x - width/2, gameObject.transform.position.y - height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 upperRightPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x + width/2, gameObject.transform.position.y + height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 upperLeftPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x - width/2, gameObject.transform.position.y + height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 lowerRightPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x + width/2, gameObject.transform.position.y - height/2, gameObject.transform.position.z - depth/2 ) );

		float xPixelDistance = Mathf.Abs( lowerLeftPoint.x - upperRightPoint.x );
		float yPixelDistance = Mathf.Abs ( lowerLeftPoint.y - upperRightPoint.y );

		print( "This is the X pixel distance: " + xPixelDistance + " This is the Y pixel distance: " + yPixelDistance );
		print ("This is the lower left pixel point: " + lowerLeftPoint);
		print(" This is the upper left point: " + upperLeftPoint );
		print ("This is the lower right pixel point: " + lowerRightPoint);
		print(" This is the upper right pixel point: " + upperRightPoint);
	}
	void OnAwake() {
	}
	void Update() {
		myTouches = Input.touches;
		//ScalePlayer ();
	}
	// Update is called once per frame
	void FixedUpdate() {
		if (rgb2d == null) {
			print ("Why is RGB2D null?");
		}
		if (gameManager.gameRunning) {
			if (myTouches != null && myTouches.Length <= 2) {
				for (int i = 0; i < myTouches.Length; i++) {
					Vector3 touchVector = Camera.main.ScreenToWorldPoint((new Vector3 (myTouches[i].position.x, myTouches[i].position.y, 0)));
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
	//Function to animate the tail of the player
	void CreateTail () {
	}
}
