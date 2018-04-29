using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinFormationPrefab;

	private Animator animator;

	private GameObject pinFormation;
	private PinCounter pinCounter;
	private GameManager gameManager;


	private Vector3 renewPos;

	// Use this for initialization
	void Start () {

		if (GetComponent<Animator> ()) {
			animator = GetComponent<Animator> ();
		} else {Debug.LogWarning ("Missing Animator.");}
		if (GameObject.Find ("PinFormation")) {
			pinFormation = GameObject.Find ("PinFormation");
			renewPos = GameObject.Find ("PinFormation").transform.position;
		} else {Debug.LogWarning ("Missing PinFormation.");}

		if (GameObject.FindObjectOfType<PinCounter>()) {
			pinCounter = GameObject.FindObjectOfType<PinCounter>();
		} else {Debug.LogWarning ("Missing pinCounter.");}

		if (GameObject.FindObjectOfType<GameManager>()) {
			gameManager = GameObject.FindObjectOfType<GameManager>();
		} else {Debug.LogWarning ("Missing gameManager.");}
	}


	#region Define what to do

	public void SwiperAction (ActionMaster.Action action){
		// Beware !! any actionMaster.Bowl() will push the bowl count.
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
			pinCounter.Tidy();
		}else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		}else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		}else if (action == ActionMaster.Action.EndGame) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
			throw new UnityException ("Don't know what to do now.");
		}
	}
	#endregion

	#region Methods that really do things to the pins.
	public void PinsRaise(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {	
			pin.Raise ();
		}
	}

	public void PinsLower(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.Lower ();
			pinCounter.LastStandCountReset();
			gameManager.PinCountUpdate (Color.black, -1);
		}
	}

	public void PinsRenew(){
		Destroy (pinFormation);
		pinFormation = Instantiate (pinFormationPrefab,renewPos,Quaternion.identity);
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.Raise ();
		}
		gameManager.PinCountUpdate (Color.black, 10);
	}
	#endregion

}
