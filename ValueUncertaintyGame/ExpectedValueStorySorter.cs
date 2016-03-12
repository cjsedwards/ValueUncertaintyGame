using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame
{
	public class ExpectedValueStorySorter : ICostStorySorter
	{
		public List<IStory> Sort( ConcurrentDictionary<IStory, ValueCostEstimate> estimates )
		{
			return estimates
				.OrderByDescending( pair => pair.Value.Value / pair.Value.Cost )
				.Select( pair => pair.Key )
				.ToList();
		}
	}
}