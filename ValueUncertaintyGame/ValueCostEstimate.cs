namespace ValueUncertaintyGame
{
	public struct ValueCostEstimate
	{
		public readonly double Value;
		public readonly double Cost;

		public ValueCostEstimate( double value, double cost )
		{
			Value = value;
			Cost = cost;
		}

		public ValueCostEstimate AddRoll( double value, int runsSinceLastWin )
		{
			return new ValueCostEstimate( Value + value, Cost + runsSinceLastWin );
		}

		public ValueCostEstimate DivideByNumberOfWins( int wins )
		{
			return new ValueCostEstimate( Value / wins, Cost / wins );
		}
	}
}