using System.Collections.Generic;

namespace ValueUncertaintyGame.Accepters
{
	public interface IDiceRollsAccepter
	{
		bool Accept( IEnumerable<DiceResult> results );
	}
}