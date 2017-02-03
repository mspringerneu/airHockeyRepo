using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gc_messages_controller : MonoBehaviour
{
	private Text[] p1_messages;
	private Text p1_p1score;
	private Text p1_p2score;
	private Text p1_gcMessage;
	private Text[] p2_messages;
	private Text p2_p1score;
	private Text p2_p2score;
	private Text p2_gcMessage;
	private static int p1score = 0;
	private static int p2score = 0;
	private int scoreLimit;
	// Use this for initialization
	void Start ()
	{
		p1_messages = GameObject.FindGameObjectWithTag ("p1canvas").GetComponentsInChildren<Text> ();
		p2_messages = GameObject.FindGameObjectWithTag ("p2canvas").GetComponentsInChildren<Text> ();
		foreach (Text p1_text in p1_messages) {
			if (p1_text.CompareTag ("p1score")) {
				p1_p1score = p1_text;
			} else if (p1_text.CompareTag ("p2score")) {
				p1_p2score = p1_text;
			} else if (p1_text.CompareTag ("gc_messages")) {
				p1_gcMessage = p1_text;
			}
		}
		foreach (Text p2_text in p2_messages) {
			if (p2_text.CompareTag ("p1score")) {
				p2_p1score = p2_text;
			} else if (p2_text.CompareTag ("p2score")) {
				p2_p2score = p2_text;
			} else if (p2_text.CompareTag ("gc_messages")) {
				p2_gcMessage = p2_text;
			}
		}
		scoreLimit = 5;
	}

	void Update ()
	{
		p1_p1score.text = "Player 1: " + p1score.ToString ();
		p1_p2score.text = "Player 2: " + p2score.ToString ();
		p2_p1score.text = "Player 1: " + p1score.ToString ();
		p1_p2score.text = "Player 2: " + p2score.ToString ();
	}

	public void startGameMessages ()
	{
		wait3 ();
		p1_gcMessage.text = "READY";
		p2_gcMessage.text = "READY";
		wait1 ();
		p1_gcMessage.text = "YOUR SERVE";
		p2_gcMessage.text = "OPPONENT SERVING";
		wait1 ();
		p1_gcMessage.text = "3";
		p2_gcMessage.text = "3";
		wait1 ();
		p1_gcMessage.text = "2";
		p2_gcMessage.text = "2";
		wait1 ();
		p1_gcMessage.text = "1";
		p2_gcMessage.text = "1";
		wait1 ();
		p1_gcMessage.text = "";
		p2_gcMessage.text = "";
	}

	public void endGameMessages (string winner)
	{
		p1_gcMessage.text = "GAME OVER";
		p2_gcMessage.text = "GAME OVER";
		wait1 ();
		switch (winner) {
		case "player1":
			p1_gcMessage.text = "YOU WON!";
			p2_gcMessage.text = "YOU LOST :(";
			break;
		case "player2":
			p2_gcMessage.text = "YOU WON!";
			p1_gcMessage.text = "YOU LOST :(";
			break;
		default:
			break;
		}
		wait1 ();
		p1_gcMessage.text = "NEW GAME?";
		p2_gcMessage.text = "NEW GAME?";
	}

	public void resetGame() {
		resetScores ();
		p1_p1score.text = "";
		p2_p1score.text = "";
		p1_p2score.text = "";
		p2_p2score.text = "";
		p1_gcMessage.text = "";
		p2_gcMessage.text = "";
	}

	public void resetScores ()
	{
		p1score = 0;
		p2score = 0;
	}

	public void p1ScoresMessages ()
	{
		p1score += 1;
		p1_gcMessage.text = "YOU SCORED!";
		p2_gcMessage.text = "OPPONENT SCORED :(";
		wait1 ();
		if (p1score < scoreLimit) {
			p1_gcMessage.text = "OPPONENT SERVING";
			p2_gcMessage.text = "YOUR SERVE";
			wait1 ();
			p1_gcMessage.text = "3";
			p2_gcMessage.text = "3";
			wait1 ();
			p1_gcMessage.text = "2";
			p2_gcMessage.text = "2";
			wait1 ();
			p1_gcMessage.text = "1";
			p2_gcMessage.text = "1";
			wait1 ();
			p1_gcMessage.text = "";
			p2_gcMessage.text = "";
		} else {
			p1_gcMessage.text = "";
			p2_gcMessage.text = "";
		}
	}

	public void p2ScoresMessages ()
	{
		p2score += 1;
		p2_gcMessage.text = "YOU SCORED!";
		p1_gcMessage.text = "OPPONENT SCORED :(";
		wait1 ();
		if (p2score < scoreLimit) {
			p2_gcMessage.text = "OPPONENT SERVING";
			p1_gcMessage.text = "YOUR SERVE";
			wait1 ();
			p1_gcMessage.text = "3";
			p2_gcMessage.text = "3";
			wait1 ();
			p1_gcMessage.text = "2";
			p2_gcMessage.text = "2";
			wait1 ();
			p1_gcMessage.text = "1";
			p2_gcMessage.text = "1";
			wait1 ();
			p1_gcMessage.text = "";
			p2_gcMessage.text = "";
		} else {
			p1_gcMessage.text = "";
			p2_gcMessage.text = "";
		}
	}

	IEnumerator wait1() {
		yield return new WaitForSeconds (1);
	}

	IEnumerator wait3() {
		yield return new WaitForSeconds (3);
	}

	public int getP1Score ()
	{
		return p1score;
	}

	public int getP2Score ()
	{
		return p2score;
	}


}
