using PtProgramTrackerApi.Domain.Enums;
using PtProgramTrackerApi.Domain.Inputs;

namespace PtProgramTrackerApi.Domain.Entities
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public Exercise(ExerciseInput input)
        {
            Name = input.Name;
            Type = input.Type;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ExerciseType Type { get; set; }
    }
}
