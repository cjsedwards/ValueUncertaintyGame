using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class TwoOrMoreOfAKindAccepter : IDiceRollsAccepter
	{
		private readonly DiceResult _expected;

		public TwoOrMoreOfAKindAccepter( DiceResult expected )
		{
			_expected = expected;
		}

		public bool Accept( IEnumerable<DiceResult> results )
		{
			return results.Count( r => r == _expected ) >= 2;
		}
	}
}