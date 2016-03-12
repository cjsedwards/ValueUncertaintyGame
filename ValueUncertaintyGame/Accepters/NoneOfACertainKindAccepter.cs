using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame.Accepters
{
	public class NoneOfACertainKindAccepter : IDiceRollsAccepter
	{
		private readonly DiceResult _certainKind;

		public NoneOfACertainKindAccepter( DiceResult certainKind )
		{
			_certainKind = certainKind;
		}

		public bool Accept( IEnumerable<DiceResult> results )
		{
			return results.All( r => r != _certainKind );
		}
	}
}