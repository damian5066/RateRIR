namespace RateRIR
{
    public abstract class ExerciseBase : IExercise
    {
        public delegate void RatingAddedDelegate(object sender, EventArgs args);

        public abstract event RatingAddedDelegate RatingAdded;
        public ExerciseBase()
        {
            this.Name = "Bench_Press";
        }
        public string Name { get; private set; }

        public abstract void AddRating(float rate);

        public void AddRating(string rate)
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

        public void AddRating(int rate)
        {
            float rateAsFloat = (float)rate;
            this.AddRating(rateAsFloat);
        }

        public void AddRating(double rate)
        {
            float rateAsFloat = (float)rate;
            this.AddRating(rateAsFloat);
        }

        public void AddRating(char rate)
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
        public abstract Statistics GetStatistics();
    }
}
