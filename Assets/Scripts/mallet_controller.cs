using UnityEngine;
using System.Collections;

public class mallet_controller : MonoBehaviour {
	private GameObject mallet;
	private Rigidbody malletRb;
	private Vector3 initPos, currentPos;
	private LayerMask tableLayer;
	private GameObject controller;
	private Vector3 targetPoint;
	private Rigidbody coll;
	private Rigidbody puckRb;
	private GameObject puck;
	public float inputPadding = 0.0f;
	public float inputSpeed = 2.0f;
	public float playerSpeed;
	public float puckSpeed;

	// mallet diameter 4 1/2"

	// surface length 98
	// edge of rink is z = 1
	// min z = 3.25
	// max z = 30.125
	// surface width 50      (x = 25)
	// surface height 12

	// origin centered at p1 edge of rink (25, 0, 97

	// blue line edge 15 5/8" from center line
	// 48" - 15 5/8" = 32 3/8"

	// Use this for initialization
	void Start () {
		mallet = GameObject.FindGameObjectWithTag("player_mallet");
		malletRb = mallet.GetComponent<Rigidbody> ();
		initPos = mallet.GetComponent<Transform>().position;
		tableLayer = 1 << LayerMask.NameToLayer ("surface");
		controller = GameObject.FindGameObjectWithTag ("GameController");

		// ai = GameObject.Find ("AI").GetComponent<AI> ();
		coll = GameObject.Find("Rink/Boards").GetComponentInChildren<Rigidbody> ();
		puckRb = GameObject.FindGameObjectWithTag ("puck").GetComponent<Rigidbody> ();
		puck = GameObject.FindGameObjectWithTag ("puck");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*
		currentPos = mallet.GetComponent<Transform>().position;
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(mouseRay, out hit, 1000f)) {
			hit.
			if (hit.collider.material.name == "RinkSurface") {
				targetPoint = hit.point;
				print ("Hit at point: " + targetPoint);
				if (Vector3.Distance(currentPos, targetPoint) > inputPadding) {
					mallet.transform.position.Set (targetPoint.x, targetPoint.y, targetPoint.z);

				Vector3 pos  = Vector3.Lerp(currentPos, targetPoint, Time.deltaTime * inputSpeed);

					print ("Moving mallet from point: " + currentPos + " to point: " + targetPoint);
				}
			}
		}
		*/
	}

	void Update() {
		Vector3 malletVel = malletRb.velocity;
		//Input to move the player
		if (Input.GetKey ("left")) {
			if (malletVel.x > 0 || transform.position.x <= -21.75f) {
				malletRb.velocity = new Vector3 (0, malletVel.y, malletVel.z);
			}
			malletRb.velocity += new Vector3 (-playerSpeed * Time.deltaTime, 0f, 0f);
			
			//transform.Translate (-playerSpeed * Time.deltaTime, 0f, 0f);
		}
			
		if (Input.GetKey ("right")) {
			if (malletVel.x < 0 || transform.position.x >= 21.75f) {
				malletRb.velocity = new Vector3 (0, malletVel.y, malletVel.z);
			}
			malletRb.velocity += new Vector3 (playerSpeed * Time.deltaTime, 0f, 0f);
			
			//transform.Translate (playerSpeed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey ("up")) {
			if (malletVel.z < 0 || transform.position.z >= 40.0f) {
				malletRb.velocity = new Vector3 (malletVel.x, malletVel.y, 0f);
			}
			malletRb.velocity += new Vector3 (0f, 0f, playerSpeed * Time.deltaTime);

			//transform.Translate (0f, 0f, playerSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("down")){
			if (malletVel.z > 0 || transform.position.z <= 3f) {
				malletRb.velocity = new Vector3 (malletVel.x, malletVel.y, 0f);
			}
			malletRb.velocity += new Vector3 (0f, 0f, -playerSpeed * Time.deltaTime);
			//transform.Translate (0f, 0f, -playerSpeed * Time.deltaTime);
		}

		//Collision detection with edges, basically we are restricting player movement

		if (transform.position.x <= -21.75f)
			transform.position = new Vector3 (-21.75f, transform.position.y, transform.position.z);
		if (transform.position.x >= 21.75f)
			transform.position = new Vector3 (21.75f, transform.position.y, transform.position.z);
		if (transform.position.z >= 40.0f)
			transform.position = new Vector3 ( transform.position.x, transform.position.y, 40.0f);
		if (transform.position.z <= 3.5f)
			transform.position = new Vector3 ( transform.position.x, transform.position.y, 3.5f);

	}

	void OnCollisionEnter(Collision c) {
		print("Collision!");
		if (c.gameObject.tag == "puck") {
			print("puck collision!");
			// ai.counter = 0f; //see AI.cs for explanation


			// 1/2* m1 * v1^2 + 1/2 * m2 * v2^2
			//Controls to hit the striker
			/*
			if (Input.GetKey ("space")) { //if you keep space pressed and up arrow key and then touch, stiker is smashed
				//---Control Part---
				if (Input.GetKey ("up")) {
					if (Input.GetKey ("right")) {
						puckRb.velocity = new Vector3 (puckSpeed, puckRb.velocity.y, puckSpeed);
					} else {
						puckRb.velocity = new Vector3 (-puckSpeed, puckRb.velocity.y, puckSpeed);
					}
				}



			} else { //no space pressed and then touch then a gentle push is given

				if (Input.GetKey ("right")) {
					puckRb.velocity = new Vector3 (puckSpeed * 0.5f, 0, puckSpeed * 0.60f);
				} else {
					puckRb.velocity = new Vector3 (puckSpeed * -0.5f, 0, puckSpeed * 0.60f);
				}
			}
			*/
		}
	}
	/*
	void newPoint(bool whoseServe) {
		if (controller.isPlayerServe) {
			
		}
	}
	*/
}
