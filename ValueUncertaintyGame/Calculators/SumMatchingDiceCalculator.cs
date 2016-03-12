using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Calculators
{
	public class SumMatchingDiceCalculator : IDiceValueCalculator
	{
		public int Calculate( IEnumerable<DiceResult> results )
		{
			var list = results.ToList();
			return list.Sum(
				result => list.Count( resultToCount => resultToCount == result ) > 1 ? DiceResultHelpers.GetDiceResultValue( result ) : 0 );
		}
	}
}