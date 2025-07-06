using PtProgramTrackerApi.Domain.Enums;

namespace PtProgramTrackerApi.Domain.Dtos
{
    public class ExerciseDto
    {
        public string Name { get; set; }

        public ExerciseType Type { get; set; }
    }
}
