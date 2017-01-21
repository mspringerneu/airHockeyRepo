using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_controller : MonoBehaviour {
	private bool isPlayerServe;
	private static int playerScore;
	private static int opponentScore;
	private int maxScore;
	private GameObject player1Canvas;
	private GameObject player2Canvas;
	// Use this for initialization
	void Awake () {
		player1Canvas = GameObject.FindGameObjectWithTag ("p1canvas");
		player2Canvas = GameObject.FindGameObjectWithTag ("p2canvas");
		isPlayerServe = true;
		playerScore = 0;
		opponentScore = 0;
		maxScore = 5;
	}
	
	// Update is called once per frame
	void Update () {
		Text[] p1scores = player1Canvas.GetComponentsInChildren<Text> ();
		foreach (Text p1score in p1scores) {
			if (p1score.CompareTag("p1score")) {
				p1score.text = "Player 1: " + playerScore.ToString ();
			}
			else if (p1score.CompareTag("p2score")) {
				p1score.text = "Player 2: " + opponentScore.ToString ();
			}
		}

		Text[] p2scores = player2Canvas.GetComponentsInChildren<Text> ();
		foreach (Text p2score in p2scores) {
			if (p2score.CompareTag("p1score")) {
				p2score.text = "Player 1: " + playerScore.ToString ();
			}
			else if (p2score.CompareTag("p2score")) {
				p2score.text = "Player 2: " + opponentScore.ToString ();
			}
		}
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

	public void startGame() {
		
	}

	public void reset() {
		isPlayerServe = true;
		playerScore = 0;
		opponentScore = 0;
	}

	public void playerScores() {
		playerScore += 1;
		if (playerScore == maxScore) {
			endGame ("player");
		}
	}

	public void opponentScores() {
		opponentScore += 1;
		if (opponentScore == maxScore) {
			endGame ("opponent");
		}
	}

	public void endGame(string winner) {
		if (winner == "player") {
			
		}
		else if (winner == "opponent") {
			
		}
	}
}
