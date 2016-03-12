using Moq;
using NUnit.Framework;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class GameTest
	{
		private Game _testSubject;

		[SetUp]
		public void SetUp()
		{
		}

		[Test]
		public void TotalAcceptedPointsIsSumofSuccessfulRolls()
		{
			var story1 = new Mock<IStory>();
			var story2 = new Mock<IStory>();
			_testSubject = new Game( new[] { story1.Object, story2.Object });
			const int roll1 = 555;
			const int roll2 = 44;
			const int roll3 = 123;

			story1.Setup( s => s.Roll() ).Returns( new RollResult( true, roll1 ) );
			_testSubject.AttemptStory( story1.Object );
			story2.Setup( s => s.Roll() ).Returns( new RollResult( false, roll2 ) );
			_testSubject.AttemptStory( story2.Object );
			story2.Setup( s => s.Roll() ).Returns( new RollResult( true, roll3 ) );
			_testSubject.AttemptStory( story2.Object );

			Assert.That( _testSubject.AcceptedPoints, Is.EqualTo( roll1 + roll3 ) );
		}

		[Test]
		public void CommitmentPointsScoredAtEndOfIteration()
		{
			var story1 = new Mock<IStory>();
			var story2 = new Mock<IStory>();
			var story3 = new Mock<IStory>();
			_testSubject = new Game( new[] {story1.Object, story2.Object, story3.Object} )
			{
				MinimumIterationCommitment = 2,
				DaysInIteration = 3,
				CommitmentPointsPerStory = 5
			};

			const int roll1 = 555;
			const int roll2 = 44;
			const int roll3 = 123;

			var committedStories = new[] {story1.Object, story2.Object};
			_testSubject.StartIteration( committedStories );

			story1.Setup( s => s.Roll() ).Returns( new RollResult( true, roll1 ) );
			_testSubject.AttemptStory( story1.Object );
			story2.Setup( s => s.Roll() ).Returns( new RollResult( true, roll2 ) );
			_testSubject.AttemptStory( story2.Object );
			story3.Setup( s => s.Roll() ).Returns( new RollResult( true, roll3 ) );
			_testSubject.AttemptStory( story3.Object );

			Assert.That( _testSubject.CommitmentPoints, Is.EqualTo( committedStories.Length * _testSubject.CommitmentPointsPerStory ) );
		}

		[Test]
		public void NoCommitmentPointsScoredIfSomeCommitmentsWereNotMet()
		{
			var story1 = new Mock<IStory>();
			var story2 = new Mock<IStory>();
			var story3 = new Mock<IStory>();
			_testSubject = new Game( new[] { story1.Object, story2.Object, story3.Object } )
			{
				MinimumIterationCommitment = 2,
				DaysInIteration = 3,
				CommitmentPointsPerStory = 5
			};
			const int roll1 = 555;
			const int roll2 = 44;
			const int roll3 = 123;

			var committedStories = new[] { story1.Object, story2.Object, story3.Object };
			_testSubject.StartIteration( committedStories );

			story1.Setup( s => s.Roll() ).Returns( new RollResult( true, roll1 ) );
			_testSubject.AttemptStory( story1.Object );
			story2.Setup( s => s.Roll() ).Returns( new RollResult( false, roll2 ) );
			_testSubject.AttemptStory( story2.Object );
			story2.Setup( s => s.Roll() ).Returns( new RollResult( true, roll3 ) );
			_testSubject.AttemptStory( story2.Object );

			Assert.That( _testSubject.CommitmentPoints, Is.EqualTo( 0 ) );
		}

		[Test]
		public void CountCommitmentPointsForTwoIterations()
		{
			var story1 = new Mock<IStory>();
			var story2 = new Mock<IStory>();
			_testSubject = new Game( new[] { story1.Object, story2.Object } )
			{
				MinimumIterationCommitment = 1,
				DaysInIteration = 1,
				CommitmentPointsPerStory = 5
			};
			const int roll1 = 555;
			const int roll2 = 44;

			var committedStories = new[] { story1.Object };
			_testSubject.StartIteration( committedStories );

			story1.Setup( s => s.Roll() ).Returns( new RollResult( true, roll1 ) );
			_testSubject.AttemptStory( story1.Object );


			committedStories = new[] { story2.Object };
			_testSubject.StartIteration( committedStories );

			story2.Setup( s => s.Roll() ).Returns( new RollResult( true, roll2 ) );
			_testSubject.AttemptStory( story2.Object );

			Assert.That( _testSubject.CommitmentPoints, Is.EqualTo( _testSubject.CommitmentPointsPerStory * 2 ) );
		}
	}
}
