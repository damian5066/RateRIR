using RateRIR;

namespace RateRIRTests
{
    public class Tests
    {
        [Test]
        public void WhenCollectRating_ShouldReturnCorrectStatistics()
        {
            //arrange
            var statistics = new Statistics();

            //act
            statistics.AddRating(4);
            statistics.AddRating(1);
            statistics.AddRating(0);
            statistics.AddRating(3);

            //assert
            Assert.AreEqual(4, statistics.Max);
            Assert.AreEqual(0, statistics.Min);
            Assert.AreEqual(2, statistics.Average);



        }
    }
}