using NUnit.Framework;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	public class ValueCostEstimatorTest
	{
		public static void TestStoryValueCostEstimate( Story story, double expectedCost, double expectedValue )
		{
			var estimator = new ValueCostEstimator();
			ValueCostEstimate result = estimator.Estimate( story );

			Assert.That( result.Cost, Is.InRange( expectedCost * 0.80, expectedCost * 1.20 ) );
			Assert.That( result.Value, Is.InRange( expectedValue * 0.80, expectedValue * 1.20 ) );
		}

		[Test]
		public void ThatStory1HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story1(), 2.25, 10.5 );
		}

		[Test]
		public void ThatStory2HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story2(), 1.385, 8.167 );
		}

		[Test]
		public void ThatStory3HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story3(), 6.0, 15.167 );
		}

		[Test]
		public void ThatStory4HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story4(), 9.0, 52.500 );
		}

		[Test]
		public void ThatStory5HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story5(), 1.728, 12.000 );
		}

		[Test]
		public void ThatStory6HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story6(), 1.728, 9.000 );
		}

		[Test]
		public void ThatStory7HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story7(), 1.440, 8.000 );
		}

		[Test]
		public void ThatStory8HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story8(), 1.440, 6.000 );
		}

		[Test]
		public void ThatStory9HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story9(), 1.200, 4.000 );
		}

		[Test]
		public void ThatStory10HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story10(), 1.200, 3.000 );
		}

		[Test]
		public void ThatStory11HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story11(), 1.800, 10.500 );
		}

		[Test]
		public void ThatStory12HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story12(), 3.600, 14.000 );
		}

		[Test]
		public void ThatStory13HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story13(), 4.154, 14.000 );
		}

		[Test]
		public void ThatStory14HasCorrectCostAndValueEstimate()
		{
			TestStoryValueCostEstimate( StoryFactory.Story14(), 1.200, 11.667 );
		}
	}
}