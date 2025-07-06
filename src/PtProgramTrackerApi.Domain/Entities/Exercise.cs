using PtProgramTrackerApi.Domain.Dtos;
using PtProgramTrackerApi.Domain.Enums;

namespace PtProgramTrackerApi.Domain.Entities
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public Exercise(ExerciseDto input)
        {
            Name = input.Name;
            Type = input.Type;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ExerciseType Type { get; set; }
    }
}
