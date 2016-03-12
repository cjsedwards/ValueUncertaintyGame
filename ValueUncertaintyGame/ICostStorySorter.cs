using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ValueUncertaintyGame
{
	public interface ICostStorySorter
	{
		List<IStory> Sort( ConcurrentDictionary<IStory, ValueCostEstimate> estimates );
	}
}