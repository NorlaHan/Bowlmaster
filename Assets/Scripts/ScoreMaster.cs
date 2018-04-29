using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ScoreMaster {

	enum Action {normal, spare, strike, last}; 

	// Return a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScore = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScore.Add (runningTotal);
		}

		return cumulativeScore;
	}

	// Return a list of individual frame scores, Not cumulative.
	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frameList = new List<int> ();

		#region My solution
//		int bowl = 1, actualBowl = 1 ;
//		int rollsLength = rolls.Count;
//
//		foreach (int roll in rolls) {
//			if (bowl >= 19) {							
//				if (rollsLength >= actualBowl+2) {	// bowl 21 is granted.
//					frameList.Add(rolls [actualBowl - 1] + rolls [actualBowl] + rolls [actualBowl + 1]);
//					break;
//				}else if (rollsLength >= actualBowl+1){
//					frameList.Add (rolls [actualBowl -1] + rolls [actualBowl]);
//				}	
//			}else
//			if (bowl % 2 != 0) {	// odd bowl.strike.				
//				if(roll == 10){
//					if (rollsLength >= actualBowl+2) {
//						frameList.Add(rolls [actualBowl - 1] + rolls [actualBowl] + rolls [actualBowl + 1]);
//					}
//					bowl++;
//				}
//			}else
//			if (bowl % 2 == 0) {	// even bowl.
//				if (rolls [actualBowl - 2] + rolls [actualBowl - 1] >= 10) {	// even bowl spare.
//					if (rollsLength >= actualBowl + 1) {	// Adds in framelist only when the bonus bowl is rolled.
//						frameList.Add(rolls[actualBowl-2]+ rolls[actualBowl - 1] + rolls[actualBowl]);
//					}
//				} else {
//					frameList.Add (rolls [actualBowl - 2] + rolls [actualBowl - 1]);
//				}
//			}
//			bowl++;
//			actualBowl++;
//		}
		#endregion

		#region Lecture solution
		for (int i = 1; i < rolls.Count; i+=2 ){
			if(frameList.Count == 10){break;}				// Prevent 11th frame.

			if(rolls[i-1]+rolls[i]<10){						// Normal frame without bonus.
				frameList.Add(rolls[i-1]+rolls[i]);
			}

			if(rolls.Count <= i + 1){break;}				// Ensure at least 1 look-ahead available for spare, or 2 for strike.

			if(rolls[i-1]==10){								// Strike requires next 2 bowl to caculate.
				frameList.Add(10 + rolls[i] + rolls[i+1]);
				i--;										// Strike frame has just one bowl.
			}else if (rolls[i-1] + rolls [i] ==10 ){		// Spare is already consist of 2 bowl. Requires next 1 bowl to caculate.
				frameList.Add(10+rolls[i+1]);
			}
		}

		#endregion

		return frameList;
		}



}
