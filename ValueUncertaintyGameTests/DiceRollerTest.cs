using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
    public class DiceRollerTest
    {
		[Test]
		public void ThatRandomDiceRoll()
		{
			DiceResult result = DiceRoller.Roll();

			var pass = result == DiceResult.One
			           || result == DiceResult.Two
			           || result == DiceResult.Three
			           || result == DiceResult.Four
			           || result == DiceResult.Five
			           || result == DiceResult.Six;
			Assert.True( pass );
		}

		[Test]
		public void ThatResultIsRandom()
		{
			var counter = new Dictionary<DiceResult, int>();
			var diceResultValues = Enum.GetValues( typeof( DiceResult ) );
			foreach( DiceResult result in diceResultValues )
			{
				counter[ result ] = 0;
			}

			var numberOfRuns = 1000;

			for ( int i = 0; i < numberOfRuns; i++ )
			{
				var diceResult = DiceRoller.Roll();
				counter[ diceResult ]++;
			}

			var expectedFraction = 1.0 / diceResultValues.Length;
			
			var percentTolerance = 20.0;
			foreach ( DiceResult result in diceResultValues )
			{
				var fractionOfRuns = (double) counter[ result ] / numberOfRuns;
				var percentDeviationFromExpected = Math.Abs( expectedFraction - fractionOfRuns ) / expectedFraction * 100;
				Assert.That( percentDeviationFromExpected, Is.LessThan( percentTolerance ) );
			}
		}

		[TestCase( 3 )]
		[TestCase( 4 )]
		public void ThatRollsMultipleDice( int count )
		{
			var diceResults = DiceRoller.RollMultiple( count );
			Assert.That( diceResults.Count, Is.EqualTo( count ) );
		}
    }
}
