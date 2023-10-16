using RateRIR;

namespace RareRIR
{
    public class AddRatingTests
    {
        [Test]
        public void IfAddedRating_ShouldReturnCorrectStatistics()
        {
            var ex = new ExerciseInMemory();
            ex.AddRating(2);
            ex.AddRating("4");
            ex.AddRating(1);
            ex.AddRating("5");
            var statistics = ex.GetStatistics();

            Assert.AreEqual(1, statistics.Min);
            Assert.AreEqual(5, statistics.Max);
            Assert.AreEqual(3, statistics.Average);
        }
        
    }
}
