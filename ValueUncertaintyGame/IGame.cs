using System.Collections.Generic;

namespace ValueUncertaintyGame
{
	public interface IGame
	{
		void StartIteration( IEnumerable<IStory> committedStories );
		IEnumerable<IStory> IncompleteStories { get; }
		int MinimumIterationCommitment { get; }
		IEnumerable<IStory> CommittedStories { get; }
		int AcceptedPoints { get; }
		int CommitmentPoints { get; }
		int NumberOfIterations { get; }
		int DaysInIteration { get; set; }
		List<IStory> AcceptedStories { get; }
		void AttemptStory( IStory story );
		void StartGame();
	}
}