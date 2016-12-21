using UnityEngine;
using System.Collections;

public class game_controller : MonoBehaviour {
	private bool isPlayerServe;
	private int playerScore;
	private int opponentScore;
	// Use this for initialization
	void Awake () {
		isPlayerServe = true;
		playerScore = 0;
		opponentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// if true, player gets puck, otherwise opponent gets puck
	public bool whoseServe() {
		return isPlayerServe;
	}

	public int[] scoreCount() {
		int[] score = new int[2];
		score[0] = playerScore;
		score[1] = opponentScore;
		return score;
	}
}
