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

        public abstract void AddRating(string rate);
        public abstract void AddRating(int rate);
        public abstract void AddRating(char rate);
        public abstract void AddRating(double rate);
        public abstract void AddRating(float rate);

        public abstract Statistics GetStatistics();

    }
}
