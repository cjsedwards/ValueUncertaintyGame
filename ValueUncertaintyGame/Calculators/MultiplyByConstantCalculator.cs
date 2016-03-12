using System.Collections.Generic;

namespace ValueUncertaintyGame.Calculators
{
	public class MultiplyByConstantCalculator : IDiceValueCalculator
	{
		private readonly IDiceValueCalculator _accepter;
		private readonly int _factor;

		public MultiplyByConstantCalculator( IDiceValueCalculator accepter, int factor )
		{
			_accepter = accepter;
			_factor = factor;
		}

		public int Calculate( IEnumerable<DiceResult> results )
		{
			return _accepter.Calculate( results ) * _factor;
		}
	}
}