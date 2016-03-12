using NUnit.Framework;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class GameRunnerTest
	{
		[Test]
		public void RunSingleGame()
		{
			var game = Game.GetInstance();
			var testSubject = new GameRunner( ArtificalIntelligence.NewSimpleAi( game, new ValueCostEstimator() ), game );

			GameResult results = testSubject.Run();
		}
	}
}
