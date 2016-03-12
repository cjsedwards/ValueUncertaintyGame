using System.Collections.Generic;

namespace ValueUncertaintyGame.Calculators
{
	public interface IDiceValueCalculator
	{
		int Calculate( IEnumerable<DiceResult> results );
	}
}