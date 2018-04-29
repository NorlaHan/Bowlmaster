using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NUnit.Framework;


[TestFixture]
public class ActionMasterTest { // : MonoBehaviour 

	// Shortcut to represent the enum.
	private ActionMaster.Action 
		endTurn = ActionMaster.Action.EndTurn, 
		tidy = ActionMaster.Action.Tidy,
		reset = ActionMaster.Action.Reset,
		endGame = ActionMaster.Action.EndGame;
	//private ActionMaster actionMaster;
	private List<int> pinFalls;
	//private int[] bowls = new int[21];

	[SetUp]	// Runs for every tests when they start.
	public void Setup(){
		// Arrange : ActionMaster actionMaster = new ActionMaster();
		//actionMaster = new ActionMaster ();
		pinFalls = new List<int>();
	}

	[Test]
	public void T00_PassingTest (){
		Assert.AreEqual (1, 1);
	}

	[Test]
	// Public void Method_Senario_ExpectedBehavior(){};
	public void T01_OneStrike_ReturnsEndTurn (){

		// Act : actionMaster.Bowl(10)
		// Assert : Assert.AreEqual();
		pinFalls.Add(10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02_Bowl8_ReturnsTidy(){
		pinFalls.Add (8);
		Assert.AreEqual (tidy,ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03_Bowl28Spare_ReturnsEndTurn(){
		// Without a strike i.e.Bowl(10) ,any pins will "Tidy", and any other pins will "Reset".
		int[] rolls= {2, 8};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04_Bowl20_NoSpare_ReturnEndGame(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,8 };
//		foreach (int bowl in rolls){							// bowl 1-19
//			actionMaster.Bowl(bowl);
//		}
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));		// bowl 20
	}

	[Test]
	public void T05_Bowl19Strike_Bowl20Not_ReturnsTidy(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 8 };
//		foreach (int bowl in rolls){							// bowl 1-18
//			actionMaster.Bowl(bowl);
//		}
//		//actionMaster.TestSetBowl (19);
//		actionMaster.Bowl (10); 								// bowl 19
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));			// bowl 20
	}

	[Test]
	public void T06_Bowl20Spare_ReturnsReset(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,2, 8 };
//		foreach (int bowl in rolls){							// bowl 1-18
//			actionMaster.Bowl(bowl);
//		}
//		//actionMaster.TestSetBowl (19);
//		actionMaster.Bowl (2); 									// bowl 19
		Assert.AreEqual (reset,ActionMaster.NextAction(rolls.ToList()));			// bowl 20
	}

	[Test]
	public void T07_Bowl21_ReturnsEndGame(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 6 };
//		foreach (int bowl in rolls){							// bowl 1-18
//			actionMaster.Bowl(bowl);
//		}
//		//actionMaster.TestSetBowl (19);
//		actionMaster.Bowl (10); 								// bowl 19
//		actionMaster.Bowl (1); 									// bowl 20
		Assert.AreEqual (endGame,ActionMaster.NextAction(rolls.ToList()));		// bowl 21
	}

	[Test]
	public void T08_0PinWithASpareNextBowl1_ReturnsTidy(){
		int[] rolls = {0,10,1};
//		actionMaster.Bowl (0);
//		actionMaster.Bowl (10);
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09_19Strike20Gutter_ReturnsTidy(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
//		foreach (int bowl in rolls){							// bowl 1-18
//			actionMaster.Bowl(bowl);
//		}
//		//actionMaster.TestSetBowl (19);
//		actionMaster.Bowl (10); 								// bowl 19
//		Assert.AreEqual (reset, actionMaster.Bowl (0)); 			// bowl 20
		Assert.AreEqual (tidy,ActionMaster.NextAction(rolls.ToList())); 			// bowl 20
	}

	[Test]
	public void T10_19Gutter20Spare_ReturnsReset(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10 };
//		foreach (int bowl in rolls){							// bowl 1-18
//			actionMaster.Bowl(bowl);
//		}
//		//actionMaster.TestSetBowl (19);
//		actionMaster.Bowl (0); 								// bowl 19
//		Assert.AreEqual (reset, actionMaster.Bowl (10));		// bowl 20
		Assert.AreEqual (reset,ActionMaster.NextAction(rolls.ToList()));		// bowl 20
	}

	[Test]
	public void T11_10thFrameTurky_RuturnsEndGame(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
		Assert.AreEqual (endGame,ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12_10thFrameX0_RuturnsTidy(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0};
		Assert.AreEqual (tidy,ActionMaster.NextAction(rolls.ToList()));
	}
}
