namespace PtProgramTrackerApi.Domain.Entities
{
    public class Program
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Aim { get; set; }

        public IEnumerable<Workout> Workouts { get; set; }
    }
}
