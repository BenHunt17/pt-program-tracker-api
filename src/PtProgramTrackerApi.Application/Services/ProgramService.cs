using FluentValidation;
using PtProgramTrackerApi.Application.Validators;
using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;
using PtProgramTrackerApi.Domain.Interfaces.Services;

namespace PtProgramTrackerApi.Application.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramDataAccess _programDataAccess;

        public ProgramService(IProgramDataAccess programDataAccess)
        {
            _programDataAccess = programDataAccess;
        }


        public Program GetById(int id)
        {
            return _programDataAccess.GetById(id);
        }

        public IEnumerable<Program> FindAll()
        {
            return _programDataAccess.FindAll();
        }

        public Program UpsertProgram(ProgramDto input)
        {
            new ProgramDtoValidator().ValidateAndThrow(input);

            return _programDataAccess.UpsertProgram(input);
        }

        public Program UpsertProgramWorkout(int programId, WorkoutDto input)
        {
            new WorkoutDtoValidator().ValidateAndThrow(input);

            return _programDataAccess.UpsertProgramWorkout(programId, input);
        }

        public Program RemoveProgramWorkout(int programId, int workoutId)
        {
            return _programDataAccess.RemoveProgramWorkout(programId, workoutId);
        }

        public Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds)
        {
            return _programDataAccess.UpdateProgramWorkoutExercises(programId, workoutId, exerciseIds);
        }

        public void Delete(int id)
        {
            _programDataAccess.RemoveProgram(id);
        }
    }
}
