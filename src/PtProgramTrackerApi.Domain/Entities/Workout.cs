namespace PtProgramTrackerApi.Domain.Entities
{
    public class Workout
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
