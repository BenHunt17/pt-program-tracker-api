using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IProgramService
    {
        Program GetById(int id);

        IEnumerable<Program> FindAll();

        Program UpsertProgram(ProgramDto input);

        Program UpsertProgramWorkout(int programId, WorkoutDto input);

        Program RemoveProgramWorkout(int programId, int workoutId);

        Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds);

        void Delete(int id);
    }
}
