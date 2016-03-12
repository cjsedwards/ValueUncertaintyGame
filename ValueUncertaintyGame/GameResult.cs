namespace ValueUncertaintyGame
{
	public struct GameResult
	{
		public GameResult( int acceptedPoints, int commitmentPoints, int numAcceptedStories )
		{
			AcceptedPoints = acceptedPoints;
			CommitmentPoints = commitmentPoints;
			NumAcceptedStories = numAcceptedStories;
		}

		public int AcceptedPoints { get; }
		public int CommitmentPoints { get; }
		public int NumAcceptedStories { get; }
	}
}