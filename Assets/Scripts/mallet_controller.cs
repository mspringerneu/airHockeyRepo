using UnityEngine;
using System.Collections;

public class mallet_controller : MonoBehaviour {
	private Vector3 initPos = new Vector3 (2.25f, 0.1f, 6f);
	private LayerMask tableLayer;
	private GameObject controller;
	private Vector3 targetPoint;
	public float inputPadding = 0.0f;
	public float inputSpeed = 2.0f;

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
		tableLayer = 1 << LayerMask.NameToLayer ("Table");
		transform.position = initPos;
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(mouseRay, out hit, tableLayer)) {
			targetPoint = hit.point;
		}
	}

	void Update() {
		if (Vector3.Distance(transform.position, targetPoint) > inputPadding) {
			Vector3 pos  = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime * inputSpeed);
			transform.position = new Vector3(pos.x, transform.position.y, pos.z);
		}
	}
	/*
	void newPoint(bool whoseServe) {
		if (controller.isPlayerServe) {
			
		}
	}
	*/
}
