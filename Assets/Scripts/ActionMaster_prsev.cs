//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ActionMaster {
//
//	public enum Action {Tidy, Reset, EndTurn, EndGame};
//		// Tidy = Leave standing alone and cleanup.
//		// Reset = Cleanup all and renew without adding frame.
//		// EndTurn = Cleanup all, renew and add frame.
//		// EndGame = Cleanup all, renew and end the game.
//
//	private int[] bowls = new int[21];
//	private int bowl = 1;
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	#region Return Action according to pins and bowls.
//	public Action Bowl (int pins){
//		if (pins < 0 || pins > 10) {throw new UnityException ("Invalid pin count");}
//		//Debug.Log ("bowl "+bowl);
//		bowls[bowl-1] = pins;
//
//		// Other behavior here, e.g. last frame.
//
//		// When bowl 19 strike, bowl 21 is certain.
//		// When bowl 20,if spare, bowl 21 will be possible. else reset.
//
//		if(bowl >= 21){ // Game ends at bowl21 no matter what.
//			bowl = 1;	
//			return Action.EndGame;
//		}
//		//if (bowl >= 20) {
//		//	if (bowls[19-1] == 10 && bowls[20-1] < 10) {	// bowl19 strike but bowl20 isn't.
//		//		bowl++;
//		//		return Action.Tidy;
//		//	}
//		//	if (bowls[19-1] + bowls[20-1] >= 10) {	// Two strike or one spare.
//		//		bowl++;
//		//		return Action.Reset;
//		//	}else {
//		//		bowl = 1;	// Game ends at 20.
//		//		return Action.EndGame;
//		//	}
//		//}
//
//		if (bowl >=19 && Bowl21Awarded()){
//			bowl++;
//			if (bowls [19-1]==10 && bowls [20-1]==0) {
//				return Action.Tidy;
//			}else
//			if (pins==10 || bowls [19-1] +bowls [20-1] == 10) { // 19,20 strike, or 20 spare. !!19=10_20=0 will fail the test.
//				return Action.Reset;
//			}else {
//				return Action.Tidy;
//			}
//		}else if(bowl>=20 && !Bowl21Awarded()){
//			bowl = 1;
//			return Action.EndGame;
//		}
//			
//		if (bowl % 2 != 0) { 	// First bowl of frame.
//			if (pins == 10) {	// Strike
//				bowl += 2;
//				return Action.EndTurn;
//			} else {			
//				bowl++;
//				return Action.Tidy;
//			}
//		}
//
//		if (bowl % 2 == 0) {	// Second bowl of frame.
//			bowl++;
//			return Action.EndTurn;
//		}
//
//		throw new UnityException("Not sure what action to return!");
//	}
//
//	private bool Bowl21Awarded(){
//		return (bowls [19-1] +bowls [20-1] >= 10 );
//	}
//	#endregion
//
//	public static Action NextAction(List<int> pinFalls ){
//		ActionMaster actionMaster = new ActionMaster ();
//		Action currentAction = new Action ();
//
//		foreach (int pinFall in pinFalls) {
//			currentAction = actionMaster.Bowl (pinFall);
//		}
//		return currentAction;	// return the last result of pinFall.
//	}
//
//	// TODO Delete after complete
//	public void TestSetBowl(int bowlNow){
//		bowl = bowlNow;
//	}
//}
