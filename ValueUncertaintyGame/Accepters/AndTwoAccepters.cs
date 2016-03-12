using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class AndTwoAccepters : IDiceRollsAccepter
	{
		private readonly IDiceRollsAccepter _accepter1;
		private readonly IDiceRollsAccepter _accepter2;

		public AndTwoAccepters( IDiceRollsAccepter accepter1, IDiceRollsAccepter accepter2 )
		{
			_accepter1 = accepter1;
			_accepter2 = accepter2;
		}

		public bool Accept( IEnumerable<DiceResult> results )
		{
			var list = results.ToList();
			return _accepter1.Accept( list ) && _accepter2.Accept( list );
		}
	}
}