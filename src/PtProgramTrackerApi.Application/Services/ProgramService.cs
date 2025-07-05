using FluentValidation;
using PtProgramTrackerApi.Application.Validators;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;
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

        public Program UpsertProgram(ProgramInput input)
        {
            new ProgramInputValidator().ValidateAndThrow(input);

            return _programDataAccess.UpsertProgram(input);
        }

        public Program UpsertProgramWorkout(int programId, WorkoutInput input)
        {
            new WorkoutInputValidator().ValidateAndThrow(input);

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
