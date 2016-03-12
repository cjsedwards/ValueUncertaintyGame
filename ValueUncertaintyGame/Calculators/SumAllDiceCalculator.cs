using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Calculators
{
	public class SumAllDiceCalculator : IDiceValueCalculator
	{
		public int Calculate( IEnumerable<DiceResult> results )
		{
			return results.Sum( DiceResultHelpers.GetDiceResultValue );
		}
	}
}