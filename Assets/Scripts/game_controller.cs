using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_controller : MonoBehaviour {
	private bool is_p1_serve = true;
	private bool is_p2_serve = false;
	private bool p1_puck_active = true;
	private bool p2_puck_active = false;
	private static int playerScore = 0;
	private static int opponentScore = 0;
	private int maxScore;
	private GameObject player1Canvas;
	private GameObject player2Canvas;
	private gc_messages_controller gcMessageController;
	private mallet_controller p1_malletController;
	private opponent_mallet p2_malletController;
	private puck_controller puckController;
	private puck_controller p1_puckController;
	//private puck_controller p2_puckController;

	// Use this for initialization
	void Start () {
		player1Canvas = GameObject.FindGameObjectWithTag ("p1canvas");
		player2Canvas = GameObject.FindGameObjectWithTag ("p2canvas");
		gcMessageController = GameObject.FindGameObjectWithTag("canvas_controller").GetComponent<gc_messages_controller>();
		p1_malletController = GameObject.FindGameObjectWithTag("player_mallet").GetComponent<mallet_controller>();
		p2_malletController = GameObject.FindGameObjectWithTag("opponent_mallet").GetComponent<opponent_mallet>();
		puckController = GameObject.FindGameObjectWithTag("p1_puck").GetComponentInChildren<puck_controller>();
		p1_puckController = GameObject.FindGameObjectWithTag("p1_puck").GetComponentInChildren<puck_controller>();
		//p2_puckController = GameObject.FindGameObjectWithTag("p2_puck").GetComponentInChildren<puck_controller>();
		maxScore = 5;
		startGame ();
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
		return is_p1_serve;
	}

	public int[] scoreCount() {
		int[] score = new int[2];
		score[0] = playerScore;
		score[1] = opponentScore;
		return score;
	}

	public void startGame() {
		pauseMalletMovement ();
		gcMessageController.startGameMessages ();
		puckController.spawnPuck ("p1");
		enableMalletMovement ();
	}

	public void reset() {
		is_p1_serve = true;
		is_p2_serve = false;
		p1_puck_active = true;
		p2_puck_active = false;
		playerScore = 0;
		opponentScore = 0;
	}

	public void playerScores() {
		print ("goal scored by: p1");
		pauseMalletMovement ();
		resetMalletPositions ();
		playerScore += 1;
		gcMessageController.p1ScoresMessages ();
		if (playerScore == maxScore) {
			gcMessageController.endGameMessages("player1");
		}
		else {
			puckController.spawnPuck ("p2");
			enableMalletMovement ();
		}
	}

	public void opponentScores() {
		print ("goal scored by: p2");
		pauseMalletMovement ();
		resetMalletPositions ();
		opponentScore += 1;
		gcMessageController.p2ScoresMessages ();
		if (opponentScore == maxScore) {
			endGame ("opponent");
		}
		else {
			puckController.spawnPuck ("p1");
			enableMalletMovement ();
		}
	}

	public void endGame(string winner) {
		if (winner == "player") {
			
		}
		else if (winner == "opponent") {
			
		}
	}

	public void pauseMalletMovement() {
		print("freezing mallet movements");
		p1_malletController.pause ();
		p2_malletController.pause ();
	}

	void resetMalletPositions () {
		p1_malletController.resetPos ();
		p2_malletController.resetPos ();
	}

	public void enableMalletMovement() {
		p1_malletController.unpause ();
		p2_malletController.unpause ();
	}
}
