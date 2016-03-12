using System.Linq;
using ValueUncertaintyGame.Accepters;
using ValueUncertaintyGame.Calculators;

namespace ValueUncertaintyGame
{
	public interface IStory
	{
		RollResult Roll();
	}

	public class Story : IStory
	{
		private readonly IDiceValueCalculator _calculator;
		private readonly IDiceRollsAccepter _accepter;
		private readonly int _numberOfDice;

		public Story( IDiceValueCalculator calculator, IDiceRollsAccepter accepter, int numberOfDice )
		{
			_calculator = calculator;
			_accepter = accepter;
			_numberOfDice = numberOfDice;
		}

		public RollResult Roll()
		{
			var rolls = DiceRoller.RollMultiple( _numberOfDice );
			var list = rolls.ToList();
			return new RollResult( _accepter.Accept( list ), _calculator.Calculate( list ) );
		}
	}
}