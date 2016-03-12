namespace ValueUncertaintyGame
{
	public class GameRunner
	{
		private readonly ArtificalIntelligence _artificalIntelligence;
		private readonly IGame _game;
		public GameRunner( ArtificalIntelligence artificalIntelligence, IGame game )
		{
			_artificalIntelligence = artificalIntelligence;
			_game = game;
		}

		public GameResult Run()
		{
			_game.StartGame();
			for ( int iteration = 0; iteration < _game.NumberOfIterations; iteration++ )
			{
				_artificalIntelligence.StartIteration();
				for ( int day = 0; day < _game.DaysInIteration; day++ )
				{
					_artificalIntelligence.AttemptStory();
				}
			}
			return new GameResult( _game.AcceptedPoints, _game.CommitmentPoints, _game.AcceptedStories.Count );
		}
	}
}