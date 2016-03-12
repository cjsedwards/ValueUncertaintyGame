using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueUncertaintyGame
{
	public class ArtificalIntelligence
	{
		private readonly IGame _game;
		private readonly IValueCostEstimator _estimator;
		private readonly ICostStorySorter _storySorter;

		public static ArtificalIntelligence NewSimpleAi( IGame game, IValueCostEstimator estimator )
		{
			return new ArtificalIntelligence( game, estimator, new StoryCostSorter() );
		}

		public static ArtificalIntelligence NewOptimalAi( IGame game, IValueCostEstimator estimator )
		{
			return new ArtificalIntelligence( game, estimator, new ExpectedValueStorySorter() );
		}

		protected ArtificalIntelligence( IGame game, IValueCostEstimator estimator, ICostStorySorter storySorter )
		{
			_game = game;
			_estimator = estimator;
			_storySorter = storySorter;
		}

		public void StartIteration()
		{
			var storiesSortedByPreference = StoriesSortedByPreference;

			var storiesToCommit = new List<IStory>();
			var count = Math.Min( _game.MinimumIterationCommitment, storiesSortedByPreference.Count );
			for ( int i = 0; i < count; i++ )
			{
				storiesToCommit.Add( storiesSortedByPreference[i] );
			}
			_game.StartIteration( storiesToCommit );
		}

		private List<IStory> StoriesSortedByPreference
		{
			get
			{
				var incompleteStories = _game.IncompleteStories;
				var estimates = new ConcurrentDictionary<IStory, ValueCostEstimate>();

				Parallel.ForEach( incompleteStories, incompleteStorey =>
					{
						estimates[ incompleteStorey ] = _estimator.Estimate( incompleteStorey );
					} );

				var storiesSortedByPreference = _storySorter.Sort( estimates );

				return storiesSortedByPreference;
			}
		}

		public void AttemptStory()
		{
			var committedStories = _game.CommittedStories;

			var story = committedStories.FirstOrDefault( s => _game.IncompleteStories.Contains( s ) );
			if ( story == null )
			{
				var storiesEasiestFirst = StoriesSortedByPreference;
				story = storiesEasiestFirst.FirstOrDefault();
			}
			if ( story != null )
			{
				_game.AttemptStory( story );
			}
		}
	}
}