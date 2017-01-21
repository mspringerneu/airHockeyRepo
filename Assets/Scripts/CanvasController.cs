using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
	public Text p1text;
	public Text p2text;
	GameObject gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController");
		p1text = GameObject.FindGameObjectWithTag ("p1score").GetComponent<Text> ();
		p2text = GameObject.FindGameObjectWithTag ("p2score").GetComponent<Text> ();
	}
}
