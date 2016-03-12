namespace ValueUncertaintyGame
{
	public interface IValueCostEstimator
	{
		ValueCostEstimate Estimate( IStory story1 );
	}
}