
namespace RateRIR
{
    public interface IExercise
    {
        string Name { get; }
        void AddRating(float rate);
        void AddRating(string rate);
        void AddRating(int rate);
        void AddRating(char rate);
        void AddRating(double rate);
        Statistics GetStatistics();
    }
}
