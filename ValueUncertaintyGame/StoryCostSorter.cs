using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame
{
	public class StoryCostSorter : ICostStorySorter
	{
		public List<IStory> Sort( ConcurrentDictionary<IStory, ValueCostEstimate> estimates )
		{
			return estimates
				.OrderBy( pair => pair.Value.Cost )
				.Select( pair => pair.Key )
				.ToList();
		}
	}
}