using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Calculators
{
	public class HighestDieCalculator : IDiceValueCalculator
	{
		public int Calculate( IEnumerable<DiceResult> results )
		{
			return results.Max( DiceResultHelpers.GetDiceResultValue );
		}
	}
}