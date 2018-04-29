using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject cheatButton;
	//private ActionMaster actionMaster = new ActionMaster ();
	private BowlingBall ball;
	private PinSetter pinSetter;
	//private ScoreMaster scoreMaster;
	private ScoreDisplay scoreDisplay;
	// ScoreDisplay

	private Text pinCount;
	private List<int> rolls = new List<int>();
	private PinCounter pinCounter;
	private GameObject howToPlay,gameOver;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("PinCount")) {
			pinCount = GameObject.Find ("PinCount").GetComponent<Text> ();
		} else {Debug.LogWarning ("Missing PinCount text object.");}

		if (GameObject.FindObjectOfType<BowlingBall> ()) {
			ball = GameObject.FindObjectOfType<BowlingBall> ();
		} else {Debug.LogWarning ("Missing BowlingBall.");}

		if (GameObject.FindObjectOfType<PinSetter> ()) {
			pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		} else {Debug.LogWarning ("Missing PinSetter.");}
		if (GameObject.FindObjectOfType<PinCounter> ()) {
			pinCounter = GameObject.FindObjectOfType<PinCounter> ();
		} else {Debug.LogWarning ("Missing pinCounter.");}
		if (GameObject.FindObjectOfType<ScoreDisplay> ()) {
			scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
		} else {Debug.LogWarning ("Missing ScoreDisplay.");}
		if (GameObject.Find("HowToPlay")) {
			howToPlay = GameObject.Find ("HowToPlay");
		}else {Debug.LogWarning ("Missing HowToPlay.");}
		if (GameObject.Find("GameOver")) {
			gameOver = GameObject.Find ("GameOver");
			gameOver.SetActive (false);
		}else {Debug.LogWarning ("Missing GameOver.");}
//		if (GameObject.Find("CheatButton")) {
//			cheatButton = GameObject.Find ("CheatButton");
//		}else {Debug.LogWarning ("Missing CheatButton.");}

		PinCountUpdate (Color.black, -1);

		//pinCount.text = pinCounter.CountStanding ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Left UI panel Pin count display.
	public void PinCountUpdate(Color color,int pinNum ){
		if (pinNum >= 0) {
			pinCount.text = pinNum.ToString ();
		} else {
			pinCount.text = pinCounter.CountStanding ().ToString();
		}
		pinCount.color = color;
	}

	public void Bowl(int pinFall){
		ball.Reset ();
		// Prevent pins fall adding to List rolls if Endgame.
		if (ActionMaster.NextAction (rolls)==ActionMaster.Action.EndGame) {
			Debug.LogWarning ("Game ends, please reset.");
			return;
		}
		try{
			rolls.Add (pinFall);
			// Will run through all the list,but will only return the last action.
			pinSetter.SwiperAction(ActionMaster.NextAction (rolls));
		}catch{
			Debug.LogWarning ("Error occurs at Bowl()");
		}
			if (ActionMaster.NextAction (rolls)==ActionMaster.Action.EndGame) {
				cheatButton.SetActive(true);
				gameOver.SetActive (true);
				Debug.LogWarning ("Game ends, please reset.");
			}

		//print ("pinFall is " + pinFall + ", lastSettleCount is " + pinCounter.CountStanding () + ", " + ActionMaster.NextAction (bowls));
//		try{
		scoreDisplay.FillRolls (rolls);
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));

			//scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
//		}catch{
//			Debug.LogWarning ("Error occurs at FillRollCard()");
//		}

	}

	public void GameReset(){
		rolls = new List<int> ();
		scoreDisplay.Restart ();
		pinSetter.SwiperAction(ActionMaster.Action.Reset);
		gameOver.SetActive (false);
	}

	public void HowToPlay(){
		howToPlay.SetActive (true);
	}

//	public void BallReset(){
//		ball.Reset ();
//	}
}
