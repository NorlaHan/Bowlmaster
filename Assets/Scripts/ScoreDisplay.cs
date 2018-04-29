using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] frameTexts = new Text[10];
	public Text[] rollsTexts = new Text[21];

	// Use this for initialization
	void Start () {
		Restart ();
	}

	public void Restart (){
		foreach (Text frameText in frameTexts) {
			frameText.text = "";
		}
		foreach (Text rollsText in rollsTexts) {
			rollsText.text = "";
		}
	}

	public void FillRolls (List<int> rolls) 
	{
		string scoreString = FormatRolls (rolls);
		for (int i = 0; i < scoreString.Length; i++) {
			rollsTexts [i].text = scoreString[i].ToString();
		}
//		int i = 0;
//		foreach (int roll in rolls) 
//		{
//			if (roll == 10) 
//			{
//				rollsTexts [i].text = "X";
//				i++;
//			}else 
//				{
//					rollsTexts [i].text = roll.ToString ();
//				}
//			i++;
//			if (i > 21) 
//			{
//				i = 0;
//				Debug.Log ("rolls > 21 Reset!");
//			}
//		}
//		int ii = 0;
//		foreach (int score in ScoreMaster.ScoreCumulative(rolls)) 
//		{
//			frameTexts [ii].text = score.ToString();
//			ii++;
//			Debug.Log ("ii is " + ii);
//			if (ii >= 10) 
//			{
//				ii = 0;
//				Invoke ("Restart", 5);
//				Debug.Log ("Display Reset!");
//			}
//		}			
	}



	public void FillFrames (List<int> ScoreCumulative) 
	{
		for (int i = 0; i < ScoreCumulative.Count; i++) 
		{
			frameTexts [i].text = ScoreCumulative [i].ToString ();
		}
	}

	public static string FormatRolls (List<int> rolls)
	{
		string output="";

		#region My solution
//		int strike = 0;
//		for (int i = 0; i < rolls.Count+strike; i++) {
//			if (rolls[i-strike] == 0) {
//				output+="-";
//				Debug.Log ("rolls["+(i-strike)+"] = "+rolls[i-strike] + ", Gutter, output=" + output+".");
//			}else 
//			if (i>=18) {							// last frame
//				if (i == 18 && rolls[18-strike]==10) {	// roll 19 strike.
//					output+="X";
//					Debug.Log ("A");
//				}else if (i >= 19 && rolls[i-strike]==10 && rolls[i-1-strike]==10) { // roll before is 10, roll must be strike. 
//					output+="X";
//					Debug.Log ("B");
//				}else if (i==20 && rolls [20-strike]==10 &&	rolls [19-strike] != 0) {	// if roll 20 !=0, roll 21=10 is a strike.
//					output+="X";
//					Debug.Log ("C");
//				}else 
//				if (i>=19 && rolls[i-1-strike]!=10 && rolls[i-1-strike]+rolls[i-strike]==10) {	// after roll 20, roll before !=10, add to 10 is a spare.
//					output += "/";
//				}else 
//				{
//					output+=rolls[i-strike].ToString();
//				}
//				Debug.Log ("rolls["+(i-strike)+"] = "+rolls[i-strike] + ", Last, output=" + output+".");
//			}else
//				if ((i+1)%2 !=0 && rolls[i-strike]==10) {					// odd roll 10= strike
//				output+="X ";
//				Debug.Log ("rolls["+(i-strike)+"] = "+rolls[i-strike] + ", Strike, output=" + output+".");
//				strike++;
//				i++;
//				}else if ((i+1)%2 ==0 && rolls[i-1-strike]+rolls[i-strike]==10) {	// even roll+ earilier roll 10 = spare
//				output+="/";
//					Debug.Log ("rolls["+(i-strike)+"] = "+rolls[i-strike] + ", Spare, output=" + output+".");
//				}else{												// any roll that is not above.
//				output+=rolls[i-strike].ToString();
//				Debug.Log ("rolls["+(i-strike)+"] = "+rolls[i-strike] + ", Normal, output=" + output+".");
//			}
//		}
//		Debug.Log ("------------------------");
		#endregion
		#region Lecture
		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length+1;							// Socre box 1 to 21.
			
			if (rolls[i]==0) {									// Always enter 0 as -.
				output+= "-";
			}else if ((box%2==0 || box==21) && rolls[i-1]+rolls[i]==10) {		// Spare anywhere or box 21.
				output+="/";
			}else if (box>=19 && rolls[i] ==10) {				// Strike in frame 10.
				output+="X";
			}else if (rolls[i]==10) {							// Strike in frame 1-9.
				output +="X ";
			}else {
				output += rolls[i].ToString();					// Normal  1-9 bowl.
			}
		}
		#endregion

		return output;
	}
}
