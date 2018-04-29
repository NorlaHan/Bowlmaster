using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinCounter : MonoBehaviour {

	public int lastStandingCount = -1;
	public float timeToSettle = 3f;

	private GameManager gameManager;
	private Pin[] standingPins;

	private int standingPinCount, lastSettleCount = 10;
	private bool ballLeftBox= false;
	private float lastChangTime;

	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectOfType<GameManager>()) {
			gameManager = GameObject.FindObjectOfType<GameManager>();
		} else {Debug.LogWarning ("Missing gameManager.");}
	}
	
	// Update is called once per frame
	void Update () {
		// Start updating the pins standing state.
		if(ballLeftBox){
			UpdateStandingCountAndSettle();
		}
	}

	// Checking when the last pin falls, and count down to reset the ball.
	void UpdateStandingCountAndSettle(){
		if (CountStanding () != lastStandingCount) {
			lastChangTime = Time.time;
			lastStandingCount = CountStanding ();

			gameManager.PinCountUpdate (Color.red, CountStanding ());

			return;
		} else {
			if (lastChangTime + timeToSettle < Time.time) {
				PinHaveSettled ();
			}
		}
	}

	// An assist method for UpdateStandingCountAndSettle().
	void PinHaveSettled(){
		int pinStanding = CountStanding ();
		int pinFall = lastSettleCount - pinStanding;
		lastSettleCount = pinStanding;

		try{
			gameManager.Bowl(pinFall);
		}
		catch{
			Debug.LogWarning ("Error occur at gameManager.Bowl()");
		}
		gameManager.PinCountUpdate (Color.green, pinStanding);
	}

	public int CountStanding(){
		standingPinCount = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.isStanding()) {
				standingPinCount ++;
			}
		}return standingPinCount;
	}

	void OnTriggerEnter(Collider obj ){
		if (obj.GetComponent<BowlingBall> ()) {
			//Debug.Log ("Ball out!");
			ballLeftBox = false;
		}
	}

	void OnTriggerExit (Collider obj ){
		if (obj.GetComponent<BowlingBall> ()) {
			//Debug.Log ("Ball out!");
			ballLeftBox = true;
		}
	}

	public void Reset(){
		lastSettleCount = 10;
	}

	public void Tidy(){
		lastSettleCount = CountStanding ();
	}

	public void LastStandCountReset(){
		lastStandingCount = -1;
	}
}
