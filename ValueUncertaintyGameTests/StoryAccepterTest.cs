using NUnit.Framework;
using ValueUncertaintyGame;
using ValueUncertaintyGame.Accepters;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class StoryAccepterTest
	{
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Three }, true )]
		[TestCase( new[] { DiceResult.One, DiceResult.Three, DiceResult.Three }, true )]
		public void Roll3Dice2OrMoreTheSame( DiceResult[] results, bool expected )
		{
			var accepter = new TwoOrMoreEqualAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Three, DiceResult.Four }, true )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Three }, true )]
		public void Roll4Dice2OrMoreTheSame( DiceResult[] results, bool expected )
		{
			var accepter = new TwoOrMoreEqualAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}


		[TestCase( new[] { DiceResult.One, DiceResult.Three }, false )]
		[TestCase( new[] { DiceResult.Three, DiceResult.Three }, true)]
		public void TwoDiceAreEqual( DiceResult[] results, bool expected )
		{
			var accepter = new TwoOrMoreEqualAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three }, true )]
		[TestCase( new[] { DiceResult.Three, DiceResult.Two, DiceResult.One }, true )]
		[TestCase( new[] { DiceResult.Four, DiceResult.Six, DiceResult.Five }, true )]
		[TestCase( new[] { DiceResult.Four, DiceResult.One, DiceResult.Five }, false)]
		[TestCase( new[] { DiceResult.Four, DiceResult.One, DiceResult.Five, DiceResult.Two }, false )]
		[TestCase( new[] { DiceResult.Four, DiceResult.One, DiceResult.Five, DiceResult.Three }, true )]
		public void ThreeConsecutiveIntegers( DiceResult[] results, bool expected )
		{
			var accepter = new ThreeConsecutiveIntegerAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three }, DiceResult.Four, true )]
		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three }, DiceResult.Three, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.Four }, DiceResult.Five, true )]
		[TestCase( new[] { DiceResult.One, DiceResult.Four }, DiceResult.Four, false )]
		[TestCase( new[] { DiceResult.Six }, DiceResult.Five, true )]
		[TestCase( new[] { DiceResult.Six }, DiceResult.Six, false )]
		public void NoneOfACertainKind( DiceResult[] results, DiceResult certainKind, bool expected )
		{
			var accepter = new NoneOfACertainKindAccepter( certainKind );
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}



		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three }, true )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Three }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.Three, DiceResult.Three }, false )]
		public void AllDifferent( DiceResult[] results, bool expected )
		{
			var accepter = new AllDifferentAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.One, DiceResult.Three }, true )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Three, DiceResult.Three, DiceResult.Three }, true )]
		public void ThreeOrMoreEqualAccepter( DiceResult[] results, bool expected )
		{
			var accepter = new ThreeOrMoreEqualAccepter();
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.Two, DiceResult.Two, DiceResult.Two, DiceResult.Three }, false )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Five, DiceResult.Four, DiceResult.Three }, true )]
		public void NoOnesAndNoTwos( DiceResult[] results, bool expected )
		{
			var accepter = new AndTwoAccepters( new NoneOfACertainKindAccepter( DiceResult.Two ),
			                                    new NoneOfACertainKindAccepter( DiceResult.One ) );
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

		[TestCase( new[] { DiceResult.One, DiceResult.Two, DiceResult.Three, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.One, DiceResult.One, DiceResult.Six, DiceResult.Four }, false )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Two, DiceResult.Two, DiceResult.Six }, true )]
		[TestCase( new[] { DiceResult.Six, DiceResult.Six, DiceResult.Six, DiceResult.Six }, true )]
		public void TwoOrMoreSixes( DiceResult[] results, bool expected )
		{
			var accepter = new TwoOrMoreOfAKindAccepter( DiceResult.Six );
			Assert.That( accepter.Accept( results ), Is.EqualTo( expected ) );
		}

	}
}
