using NUnit.Framework;
using ValueUncertaintyGame;
using ValueUncertaintyGame.Calculators;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class ValueCalculatorTest
	{
		[TestCase( new[]{ DiceResult.Six, DiceResult.Five }, 11 )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.One  }, 12 )]
		public void SumAllDice( DiceResult[] results, int expected )
		{
			var calculator = new SumAllDiceCalculator();
			Assert.That( calculator.Calculate( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.Six, DiceResult.Four }, 12 )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, 0 )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Two, DiceResult.Two, DiceResult.Four }, 6 )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.Six, DiceResult.Five }, 22 )]
		public void SumMatchingDice( DiceResult[] results, int expected )
		{
			var calculator = new SumMatchingDiceCalculator();
			Assert.That( calculator.Calculate( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.Six, DiceResult.Five }, 30 )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, 24 )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Two, DiceResult.Four }, 16 )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.Six, DiceResult.Five }, 900 )]
		public void ProductOfDiceCalculator( DiceResult[] results, int expected )
		{
			var calculator = new ProductOfDiceCalculator();
			Assert.That( calculator.Calculate( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.Six, DiceResult.Five }, 2, 60 )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, 1, 24 )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Two, DiceResult.Four }, 4, 64 )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.Six, DiceResult.Five }, 10, 9000 )]
		public void MultiplyByConstantCalculator( DiceResult[] results, int factor, int expected )
		{
			var calculator = new MultiplyByConstantCalculator( new ProductOfDiceCalculator(), factor );
			Assert.That( calculator.Calculate( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.Six, DiceResult.Five }, 6 )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, 4 )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Two }, 2 )]
		[TestCase( new[] { DiceResult.One }, 1 )]
		public void HighestDie( DiceResult[] results, int expected )
		{
			var calculator = new HighestDieCalculator();
			Assert.That( calculator.Calculate( results ), Is.EqualTo( expected ) );
		}
	}
}
