using System;
using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class ThreeConsecutiveIntegerAccepter : IDiceRollsAccepter
	{
		public bool Accept( IEnumerable<DiceResult> results )
		{
			int maxConsecutive = 0;
			int currentConsecutive = 1;

			var sortedInts = results.Select( DiceResultHelpers.GetDiceResultValue ).OrderBy( i => i ).ToList();
			for ( var i = 1; i < sortedInts.Count; i++ )
			{
				if ( sortedInts[ i ] == sortedInts[ i - 1 ] + 1 )
				{
					currentConsecutive++;

					maxConsecutive = Math.Max( maxConsecutive, currentConsecutive );
				}
				else
				{
					currentConsecutive = 1;
				}
			}
			return maxConsecutive >= 3;
		}
	}
}