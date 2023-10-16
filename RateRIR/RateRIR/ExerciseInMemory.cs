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

        public override void AddRating(string rate)
        {
            if (float.TryParse(rate, out float result))
            {
                this.AddRating(result);
            }
            else
            {
                throw new Exception("Not a float");
            }
        }

        public override void AddRating(int rate)
        {
            float rateAsFloat = (float)rate;
            this.AddRating(rateAsFloat);
        }

        public override void AddRating(double rate)
        {
            double rateAsDouble = (double)rate;
            this.AddRating(rateAsDouble);
        }

        public override void AddRating(char rate)
        {
            switch (rate)
            {
                case 'A':
                case 'a':
                    this.ratings.Add(5);
                    break;
                case 'B':
                case 'b':
                    this.ratings.Add(4);
                    break;
                case 'C':
                case 'c':
                    this.ratings.Add(3);
                    break;
                case 'D':
                case 'd':
                    this.ratings.Add(2);
                    break;
                case 'E':
                case 'e':
                    this.ratings.Add(1);
                    break;
                default:
                    throw new Exception("Wrong Letter");

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
