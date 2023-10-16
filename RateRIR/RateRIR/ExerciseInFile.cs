namespace RateRIR
{
    public class ExerciseInFile : ExerciseBase
    {
        public override event RatingAddedDelegate RatingAdded;
        private const string fileName = "ratings.txt";
        public ExerciseInFile()
            : base()
        {
        }

        public override void AddRating(float rate)
        {
            if (rate >= 0 && rate <= 5)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(rate);

                }
                if (RatingAdded != null)
                {
                    RatingAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("invalid value");
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
            float rateAsFloat = rate;
            this.AddRating(rateAsFloat);
        }

        public override void AddRating(double rate)
        {
            float rateAsFloat = (float)rate;
            this.AddRating(rateAsFloat);
        }
        public override void AddRating(char rate)
        {
            switch (rate)
            {
                case 'A':
                case 'a':
                    this.AddRating(5);
                    break;
                case 'B':
                case 'b':
                    this.AddRating(4);
                    break;
                case 'C':
                case 'c':
                    this.AddRating(3);
                    break;
                case 'D':
                case 'd':
                    this.AddRating(2);
                    break;
                case 'E':
                case 'e':
                    this.AddRating(1);
                    break;
                default:
                    throw new Exception("Wrong Letter");

            }
        }

        public override Statistics GetStatistics()
        {
            var ratingsFromFile = this.ReadRatingsFromFile();
            var result = this.CountStatistics(ratingsFromFile);
            return result;
        }

        private List<float> ReadRatingsFromFile()
        {
            var ratings = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        ratings.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return ratings;
        }

        private Statistics CountStatistics(List<float> ratings)
        {
            var statistics = new Statistics();

            foreach (var rate in ratings)
            {
                if (rate >= 0)
                {
                    statistics.AddRating(rate);
                }
            }

            return statistics;
        }
    }
}