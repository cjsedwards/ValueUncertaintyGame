using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class SimpleAiTest
	{
		private Mock<IValueCostEstimator> _estimator;
		private Mock<IGame> _game;
		private ArtificalIntelligence _testSubject;

		[SetUp]
		public void SetUp()
		{
			_estimator = new Mock<IValueCostEstimator>();
			_game = new Mock<IGame>();
			_testSubject = ArtificalIntelligence.NewSimpleAi( _game.Object, _estimator.Object );
		}

		[Test]
		public void CommitsToMinimumNumberOfEasiestStories()
		{
			var easiestStory = new Mock<IStory>();
			var middleStory = new Mock<IStory>();
			var hardestStory = new Mock<IStory>();
			var stories = new[] {easiestStory.Object, hardestStory.Object, middleStory.Object};
			var twoEasiestStories = new[] {easiestStory.Object, middleStory.Object};

			_estimator.Setup( e => e.Estimate( easiestStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 1.0 ) );
			_estimator.Setup( e => e.Estimate( middleStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 2.0 ) );
			_estimator.Setup( e => e.Estimate( hardestStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 3.0 ) );

			var mininumStoriesToCommit = 2;

			_game.Setup( g => g.IncompleteStories ).Returns( stories );
			_game.Setup( g => g.MinimumIterationCommitment ).Returns( mininumStoriesToCommit );

			_game.Setup( g => g.StartIteration( It.Is( ( IEnumerable<IStory> committedStories ) => ContainsSameElements( committedStories, twoEasiestStories ) ) ) ).Verifiable();

			_testSubject.StartIteration();

			_game.Verify();
		}

		[Test]
		public void CommitsToAtMostTheRemainingStories()
		{
			var story = new Mock<IStory>();
			var stories = new[] { story.Object };

			_estimator.Setup( e => e.Estimate( story.Object ) ).Returns( new ValueCostEstimate( 1.0, 1.0 ) );

			var mininumStoriesToCommit = 2;

			_game.Setup( g => g.IncompleteStories ).Returns( stories );
			_game.Setup( g => g.StartIteration( It.Is( ( IEnumerable<IStory> committedStories ) => ContainsSameElements( committedStories, stories ) ) ) ).Verifiable();
			_game.Setup( g => g.MinimumIterationCommitment ).Returns( mininumStoriesToCommit );

			_testSubject.StartIteration();

			_game.Verify();
		}

		[Test]
		public void AttemptsFirstCommitedStory()
		{
			var story = new Mock<IStory>();
			var committedStory = new Mock<IStory>();
			var secondCommittedStory = new Mock<IStory>();
			var stories = new[] { secondCommittedStory.Object, story.Object, committedStory.Object };
			var committedStories = new[] {committedStory.Object, secondCommittedStory.Object };

			_game.Setup( g => g.IncompleteStories ).Returns( stories );
			_game.Setup( g => g.CommittedStories ).Returns( committedStories );
			_game.Setup( g => g.AttemptStory( committedStory.Object ) ).Verifiable(); 

			_testSubject.AttemptStory();

			_game.Verify();
		}

		[Test]
		public void AttemptsEasiestStoryIfNoCommittedStories()
		{
			var easiestStory = new Mock<IStory>();
			var middleStory = new Mock<IStory>();
			var hardestStory = new Mock<IStory>();
			var incompleteStories = new[] { middleStory.Object, easiestStory.Object, hardestStory.Object };

			_estimator.Setup( e => e.Estimate( easiestStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 1.0 ) );
			_estimator.Setup( e => e.Estimate( middleStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 2.0 ) );
			_estimator.Setup( e => e.Estimate( hardestStory.Object ) ).Returns( new ValueCostEstimate( 1.0, 3.0 ) );

			_game.Setup( g => g.IncompleteStories ).Returns( incompleteStories );
			_game.Setup( g => g.CommittedStories ).Returns( Enumerable.Empty<IStory>() );

			_game.Setup( g => g.AttemptStory( easiestStory.Object ) ).Verifiable();

			_testSubject.AttemptStory();

			_game.Verify();
		}

		[Test]
		public void AttemptsSecondEasiestStoryAfterEasiestSucceeded()
		{
			var story = new Mock<IStory>();
			var committedStory = new Mock<IStory>();
			var secondCommittedStory = new Mock<IStory>();
			var stories = new[] { secondCommittedStory.Object, story.Object };
			var committedStories = new[] { committedStory.Object, secondCommittedStory.Object };

			_game.Setup( g => g.IncompleteStories ).Returns( stories );
			_game.Setup( g => g.CommittedStories ).Returns( committedStories );

			_game.Setup( g => g.AttemptStory( secondCommittedStory.Object ) ).Verifiable();

			_testSubject.AttemptStory();

			_game.Verify();
		}

		[Test]
		public void DoNothingIfNoStoriesRemain()
		{ 
			_testSubject.AttemptStory();
			_game.Verify( g => g.AttemptStory( It.IsAny<IStory>() ), Times.AtMost( 0 ) );
		}

		private static bool ContainsSameElements( IEnumerable<IStory> storiesLeft, IEnumerable<IStory> storiesRight )
		{
			var left = storiesLeft.ToList();
			var right = storiesRight.ToList();
			
			return left.Count == right.Count && left.All( story => right.Contains( story ) );
		}
	}
}
