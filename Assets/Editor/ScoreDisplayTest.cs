using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00_PassingTest()
	{
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_Bowl1_Returns1()
	{
		int[] rolls= {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T02_Bowl12_Returns12()
	{
		int[] rolls= {1, 2};
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T03_Bowl5546_Returns5R4R ()
	{
		int[] rolls= {5, 5, 4, 6};
		string rollsString = "5/4/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T04_Bowl12X_Returns12X_()
	{
		int[] rolls= {1, 2, 10};
		string rollsString = "12X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T05_Bowl12X55_Returns12X_5R ()
	{
		int[] rolls= {1, 2, 10, 5, 5};
		string rollsString = "12X 5/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T05_Bowl12X12_Returns12X_12 ()
	{
		int[] rolls= {1, 2, 10, 1, 2};
		string rollsString = "12X 12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T06_All1_ReturnsAll1()
	{
		int[] rolls= {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
		string rollsString = "11111111111111111111";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T07_All0_ReturnsAll0()
	{
		int[] rolls= {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		string rollsString = "--------------------";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T08A_Strike_ReturnsX_()
	{
		int[] rolls= {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T08B_2Strike()
	{
		int[] rolls= {10, 10};
		string rollsString = "X X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T09_12Strike()
	{
		int[] rolls= {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T10_10SpareLastGutter()
	{
		int[] rolls= { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0};
		string rollsString = "5/5/5/5/5/5/5/5/5/5/-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T11_10FSpareStrike()
	{
		int[] rolls= {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 6, 10};
		string rollsString = "1111111111111111114/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T12_10F0SpareStrike()
	{
		int[] rolls= {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 10, 10};
		string rollsString = "111111111111111111-/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}
		
	[Test]
	public void T13_10FStrikeSpare()
	{
		int[] rolls= {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 4, 6};
		string rollsString = "111111111111111111X4/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T14_10FStrike0Spare()
	{
		int[] rolls= {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0, 10};
		string rollsString = "111111111111111111X-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}

	[Test]
	public void T15_0Spare()
	{
		int[] rolls= {0, 10};
		string rollsString = "-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()) );
	}
}
