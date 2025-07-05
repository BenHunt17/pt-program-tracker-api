using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;

namespace PtProgramTrackerApi.Domain.Interfaces.DataAccess
{
    public interface IProgramDataAccess
    {
        Program GetById(int id);

        IEnumerable<Program> FindAll();

        Program UpsertProgram(ProgramInput input);

        Program UpsertProgramWorkout(int programId, WorkoutInput workoutInput);

        Program RemoveProgramWorkout(int programId, int workoutId);

        Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds);

        void RemoveProgram(int id);
    }
}
