using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.DataAccess
{
    public interface IProgramDataAccess
    {
        Program GetById(int id);

        IEnumerable<Program> FindAll();

        Program UpsertProgram(ProgramDto input);

        Program UpsertProgramWorkout(int programId, WorkoutDto workoutInput);

        Program RemoveProgramWorkout(int programId, int workoutId);

        Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds);

        void RemoveProgram(int id);
    }
}
