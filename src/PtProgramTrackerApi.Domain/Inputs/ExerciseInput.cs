using PtProgramTrackerApi.Domain.Enums;

namespace PtProgramTrackerApi.Domain.Inputs
{
    public class ExerciseInput
    {
        public string Name { get; set; }

        public ExerciseType Type { get; set; }
    }
}
