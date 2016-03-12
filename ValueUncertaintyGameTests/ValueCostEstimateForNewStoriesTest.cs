using NUnit.Framework;
using ValueUncertaintyGame;

namespace ValueUncertaintyGameTests
{
	[TestFixture]
	class ValueCostEstimateForNewStoriesTest
	{
		[Test]
		public void ThatStory1HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story1(), 2.25, 10.5 );
		}

		[Test]
		public void ThatStory2HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story2(), 10.286, 70.0 );
		}

		[Test]
		public void ThatStory3HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story3(), 6.0, 15.167 );
		}

		[Test]
		public void ThatStory4HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story4(), 9.0, 52.500 );
		}

		[Test]
		public void ThatStory5HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story5(), 3.375, 13.50 );
		}

		[Test]
		public void ThatStory6HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story6(), 3.375, 7.500 );
		}

		[Test]
		public void ThatStory7HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story7(), 13.50, 114.75 );
		}

		[Test]
		public void ThatStory8HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story8(), 1.440, 3.800 );
		}

		[Test]
		public void ThatStory9HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story9(), 1.200, 4.000 );
		}

		[Test]
		public void ThatStory10HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story10(), 1.200, 3.000 );
		}

		[Test]
		public void ThatStory11HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story11(), 8.0, 15.0 );
		}

		[Test]
		public void ThatStory12HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story12(), 3.600, 14.000 );
		}

		[Test]
		public void ThatStory13HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story13(), 4.154, 14.000 );
		}

		[Test]
		public void ThatStory14HasCorrectCostAndValueEstimate()
		{
			ValueCostEstimatorTest.TestStoryValueCostEstimate( NewStoryFactory.Story14(), 1.200, 4.667 );
		}
	}
}
