using System.Collections.Generic;

namespace ValueUncertaintyGame.Accepters
{
	public class AllDifferentAccepter : IDiceRollsAccepter
	{
		public bool Accept( IEnumerable<DiceResult> results )
		{
			return !new TwoOrMoreEqualAccepter().Accept( results );
		}
	}
}