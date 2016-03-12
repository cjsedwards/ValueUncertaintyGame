using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameRunner
{
	class Program
	{
		static void Main( string[] args )
		{
			const int numRuns = 1;


			var path = @"D:\asdf.csv";
			if ( File.Exists( path ) )
			{
				File.Delete( path );
			}

			var gameResults = new ConcurrentBag<GameResult>();
			Parallel.For( 0, numRuns, run =>
			{
				var game = Game.GetInstanceWithNewStories();
				var simpleAi = ArtificalIntelligence.NewOptimalAi( game, new ValueCostEstimator() );
				var gameRunner = new GameRunner( simpleAi, game );

				var gameResult = gameRunner.Run();
				gameResults.Add( gameResult );
				Console.WriteLine( $"{run}, {gameResult.AcceptedPoints}, {gameResult.CommitmentPoints}, {gameResult.NumAcceptedStories}" );
			} );

			using (var file =
					new StreamWriter( path ))
			{
				foreach ( var gameResult in gameResults )
				{
					WriteGameResultToFile( file, gameResult );
				}
			}
		}
	

		private static void WriteGameResultToFile( StreamWriter file, GameResult gameResult )
		{
			file.WriteLine( $"{gameResult.AcceptedPoints}, {gameResult.CommitmentPoints}, {gameResult.NumAcceptedStories}" );
        }
	}
}
