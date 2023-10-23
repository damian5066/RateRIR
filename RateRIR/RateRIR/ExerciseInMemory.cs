namespace RateRIR
{
    public class ExerciseInMemory : ExerciseBase
    {
        public override event RatingAddedDelegate RatingAdded;
        private List<float> ratings = new List<float>();

        public ExerciseInMemory()
            : base()
        {
        }

        public override void AddRating(float rate)
        {
            if (rate >= 0 && rate <= 5)
            {
                this.ratings.Add(rate);
                if (RatingAdded != null)
                {
                    RatingAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("invalid");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var rate in this.ratings)
            {
                statistics.AddRating(rate);
            }

            return statistics;
        }
    }
}
