using ValueUncertaintyGame.Accepters;
using ValueUncertaintyGame.Calculators;

namespace ValueUncertaintyGame
{
	public class StoryFactory
	{
		public static Story Story1()
		{
			return new Story( new SumAllDiceCalculator(), new TwoOrMoreEqualAccepter(), 3 );
		}

		public static Story Story2()
		{
			return new Story( new SumMatchingDiceCalculator(), new TwoOrMoreEqualAccepter(), 4 );
		}

		public static Story Story3()
		{
			return new Story( new ProductOfDiceCalculator(), new TwoOrMoreEqualAccepter(), 2 );
		}

		public static Story Story4()
		{
			return new Story( new ProductOfDiceCalculator(), new ThreeConsecutiveIntegerAccepter(), 3 );
		}

		public static Story Story5()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.One ), 3 );
		}

		public static Story Story6()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.Six ), 3 );
		}

		public static Story Story7()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.One ), 2 );
		}

		public static Story Story8()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.Six ), 2 );
		}

		public static Story Story9()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.One ), 1 );
		}

		public static Story Story10()
		{
			return new Story( new SumAllDiceCalculator(), new NoneOfACertainKindAccepter( DiceResult.Six ), 1 );
		}

		public static Story Story11()
		{
			return new Story( new SumAllDiceCalculator(), new AllDifferentAccepter(), 3 );
		}

		public static Story Story12()
		{
			return new Story( new SumAllDiceCalculator(), new AllDifferentAccepter(), 4 );
		}

		public static Story Story13()
		{
			return new Story( new SumAllDiceCalculator(), new ThreeConsecutiveIntegerAccepter(), 4 );
		}

		public static Story Story14()
		{
			return new Story( new ProductOfDiceCalculator(), new AllDifferentAccepter(), 2 );
		}
	}
}