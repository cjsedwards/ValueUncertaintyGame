using NUnit.Framework;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class DiceResultHelpersTest
	{
		[TestCase( DiceResult.One, 1 )]
		[TestCase( DiceResult.Two, 2 )]
		[TestCase( DiceResult.Three, 3 )]
		[TestCase( DiceResult.Four, 4 )]
		[TestCase( DiceResult.Five, 5 )]
		[TestCase( DiceResult.Six, 6 )]
		public void ThatResultValueIsCorrect( DiceResult diceResult, int val )
		{
			Assert.That( DiceResultHelpers.GetDiceResultValue( diceResult ), Is.EqualTo( val )  );
		}
	}
}
