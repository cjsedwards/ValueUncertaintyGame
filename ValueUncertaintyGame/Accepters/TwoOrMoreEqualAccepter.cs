using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class TwoOrMoreEqualAccepter : IDiceRollsAccepter
	{
		public bool Accept( IEnumerable<DiceResult> results )
		{
			var resultArray = results.ToList();
			for ( int i = 0; i < resultArray.Count; i++ )
			{
				for ( int j = i + 1; j < resultArray.Count; j++ )
				{
					if (resultArray[ i ] == resultArray[ j ] )
						return true;
				}
			}
			return false;
		}
	}
}