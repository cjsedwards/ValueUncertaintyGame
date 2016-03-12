using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Calculators
{
	public class ProductOfDiceCalculator : IDiceValueCalculator
	{
		public int Calculate( IEnumerable<DiceResult> results )
		{
			return results.Aggregate( 1, ( current, diceResult ) => current * DiceResultHelpers.GetDiceResultValue( diceResult ) );
		}
	}
}