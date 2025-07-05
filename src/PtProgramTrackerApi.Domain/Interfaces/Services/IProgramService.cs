using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IProgramService
    {
        Program GetById(int id);

        IEnumerable<Program> FindAll();

        Program UpsertProgram(ProgramInput input);

        Program UpsertProgramWorkout(int programId, WorkoutInput input);

        Program RemoveProgramWorkout(int programId, int workoutId);

        Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds);

        void Delete(int id);
    }
}
