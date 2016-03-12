namespace ValueUncertaintyGame
{
	public class ValueCostEstimator : IValueCostEstimator
	{
		public ValueCostEstimate Estimate( IStory story1 )
		{
			var rolls = 1000;

			ValueCostEstimate total = new ValueCostEstimate( 0.0, 0.0 );
			int wins = 0;
			int rollsSinceLastWin = 0;
			for ( var i = 0; i < rolls; i++ )
			{
				RollResult result = story1.Roll();
				rollsSinceLastWin++;
				if ( result.Passed )
				{
					wins++;
					total = total.AddRoll( result.Value, rollsSinceLastWin );
					rollsSinceLastWin = 0;
				}
			}
			return total.DivideByNumberOfWins( wins );
		}
	}
}