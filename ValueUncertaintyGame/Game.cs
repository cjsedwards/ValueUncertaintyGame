using System.Collections.Generic;
using System.Linq;

namespace ValueUncertaintyGame
{
	public class Game : IGame
	{
		public IEnumerable<IStory> IncompleteStories => _incompleteStories;

		public int MinimumIterationCommitment { get; set; } = 3;

		public IEnumerable<IStory> CommittedStories { get; private set; } = Enumerable.Empty<IStory>();

		public int AcceptedPoints { get; private set; }

		public int CommitmentPoints { get; private set; }

		public int NumberOfIterations { get; } = 3;

		public int DaysInIteration { get; set; } = 10;

		public int CommitmentPointsPerStory { get; set; } = 5;

		private int _iterationDay;
		private readonly List<IStory> _incompleteStories;
		public List<IStory> AcceptedStories { get; } = new List<IStory>();


		public Game( IEnumerable<IStory> stories )
		{
			_incompleteStories = stories.ToList();
		}

		public void StartIteration( IEnumerable<IStory> committedStories )
		{
			CommittedStories = committedStories.ToList();
			_iterationDay = 0;
		}

		public void AttemptStory( IStory story )
		{
			var rollResult = story.Roll();
			if ( rollResult.Passed )
			{
				AcceptedPoints += rollResult.Value;
				_incompleteStories.Remove( story );
				AcceptedStories.Add( story );
			}

			_iterationDay++;
			if ( _iterationDay == DaysInIteration && CommittedStories.All( s => !IncompleteStories.Contains( s ) ) )
			{
				CommitmentPoints += CommittedStories.ToList().Count * CommitmentPointsPerStory;
			}
		}

		public void StartGame()
		{
			AcceptedPoints = 0;
			CommitmentPoints = 0;
			_incompleteStories.AddRange( AcceptedStories );
			AcceptedStories.Clear();
			CommittedStories = Enumerable.Empty<IStory>();
		}

		public static IGame GetInstance()
		{
			var stories = new IStory[]
			{
				StoryFactory.Story1(),
				StoryFactory.Story2(),
				StoryFactory.Story3(),
				StoryFactory.Story4(),
				StoryFactory.Story5(),
				StoryFactory.Story6(),
				StoryFactory.Story7(),
				StoryFactory.Story8(),
				StoryFactory.Story9(),
				StoryFactory.Story10(),
				StoryFactory.Story11(),
				StoryFactory.Story12(),
				StoryFactory.Story13(),
				StoryFactory.Story14()
			};
			return new Game( stories );
		}

		public static IGame GetInstanceWithNewStories()
		{
			var stories = new IStory[]
			{
				NewStoryFactory.Story1(),
				NewStoryFactory.Story2(),
				NewStoryFactory.Story3(),
				NewStoryFactory.Story4(),
				NewStoryFactory.Story5(),
				NewStoryFactory.Story6(),
				NewStoryFactory.Story7(),
				NewStoryFactory.Story8(),
				NewStoryFactory.Story9(),
				NewStoryFactory.Story10(),
				NewStoryFactory.Story11(),
				NewStoryFactory.Story12(),
				NewStoryFactory.Story13(),
				NewStoryFactory.Story14()
			};
			return new Game( stories );
		}
}
}