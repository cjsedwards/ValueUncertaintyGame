using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class ThreeOrMoreEqualAccepter : IDiceRollsAccepter
	{
		public bool Accept( IEnumerable<DiceResult> results )
		{
			var list = results.ToList();
			return list.Any( diceResult => list.Count( r => r == diceResult ) >= 3 );
		}
	}
}