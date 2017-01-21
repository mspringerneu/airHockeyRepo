using UnityEngine;
using System.Collections;

public class puck_script : MonoBehaviour {
	private Vector3 centerPos = new Vector3(1.625f, 0.5f, 46.5f);
	private Vector3 playerInitPos = new Vector3(1.625f, 0.5f, 11f);
	private Vector3 opponentInitPos = new Vector3(1.625f, 0.5f, 82f);
	private Vector3 currentVel;
	private GameObject puck;
	private Rigidbody puckRb;
	private GameObject gameController;
	// puck diameter 3.25"

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		puck = GameObject.FindGameObjectWithTag("puck");
		puckRb = puck.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update () {
		currentVel = puckRb.velocity;
		float newPosx = transform.position.x;
		float newPosz = transform.position.z;
		float newVelx = currentVel.x;
		float newVelz = currentVel.z;
		bool constrain = false;
		if (transform.position.x > 6.5f) {
			if (transform.position.x >= 22.5f) {
				newPosx = 22.5f;
				constrain = true;
				newVelx = -(Mathf.Abs (newVelx));
			}
			if (transform.position.z >= 97.5f) {
				newPosz = 97.5f;
				constrain = true;
				newVelz = -(Mathf.Abs (newVelz));
			}
			else if (transform.position.z <= 2.5f) {
				newPosz = 2.5f;
				constrain = true;
				newVelz = Mathf.Abs (newVelz);
			}
			if (constrain) {
				transform.position = new Vector3 (newPosx, transform.position.y, newPosz);
				puckRb.velocity = new Vector3 (newVelx, 0f, newVelz);
			}

		}
		else if (transform.position.x < -6.5f) {
			if (transform.position.x <= -22.5f) {
				newPosx = -22.5f;
				constrain = true;
				newVelx = Mathf.Abs (newVelx);
			}
			if (transform.position.z >= 97.5f) {
				newPosz = 97.5f;
				constrain = true;
				newVelz = -(Mathf.Abs (newVelz));
			}
			else if (transform.position.z <= 2.5f) {
				newPosz = 2.5f;
				constrain = true;
				newVelz = Mathf.Abs (newVelz);
			}
			if (constrain) {
				transform.position = new Vector3 (newPosx, transform.position.y, newPosz);
				puckRb.velocity = new Vector3 (newVelx, 0f, newVelz);
			}

		}
		else {
			if (transform.position.z >= 100f) {
				gameController.GetComponent<game_controller> ().playerScores ();
				print ("player 1 scores!");
				Destroy (puck);
			}
			else if (transform.position.z <= 0f) {
				gameController.GetComponent<game_controller> ().opponentScores ();
				print ("player 2 scores!");
				Destroy (puck);
			}
			
		}
	}
	/*
	void OnCollisionEnter(Collision c) {
		print("Collision!");

		currentVel = puckRb.velocity;
		if (c.gameObject.tag == "side_boards") {
			print ("side_boards collision!");
			puckRb.velocity = new Vector3 (-currentVel.x, 0f, currentVel.z);
		}
		else if (c.gameObject.tag == "end_boards") {
			print ("end_boards collision!");
			puckRb.velocity = new Vector3 (currentVel.x, 0f, -currentVel.z);
		}


	}

	void onTriggerEnter(Collider other) {
		if (other.gameObject.tag == "far_goal") {
			print ("player 1 scores!");
		}
		else if (other.gameObject.tag == "near_goal") {
			print ("player 2 scores!");
		}
	}
	*/
}
