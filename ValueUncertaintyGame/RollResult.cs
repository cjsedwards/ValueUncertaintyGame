namespace ValueUncertaintyGame
{
	public struct RollResult
	{
		public readonly bool Passed;
		public readonly int Value;

		public RollResult( bool passed, int value )
		{
			Passed = passed;
			Value = value;
		}
	}
}