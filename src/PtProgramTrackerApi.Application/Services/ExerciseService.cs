using FluentValidation;
using PtProgramTrackerApi.Application.Validators;
using PtProgramTrackerApi.Domain.Dtos;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;
using PtProgramTrackerApi.Domain.Interfaces.Services;

namespace PtProgramTrackerApi.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private IExerciseDataAccess _exerciseDataAccess;

        public ExerciseService(IExerciseDataAccess exerciseDataAccess)
        {
            _exerciseDataAccess = exerciseDataAccess;
        }

        public Exercise GetById(int id)
        {
            return _exerciseDataAccess.GetById(id);
        }

        public IEnumerable<Exercise> FindAll()
        {
            return _exerciseDataAccess.FindAll();
        }

        public Exercise Create(ExerciseDto input)
        {
            new ExerciseDtoValidator().ValidateAndThrow(input);

            var exercise = new Exercise(input);

            return _exerciseDataAccess.Add(exercise);
        }

        public Exercise Update(int id, ExerciseDto input)
        {
            new ExerciseDtoValidator().ValidateAndThrow(input);

            var exercise = new Exercise(input);

            return _exerciseDataAccess.Update(id, exercise);
        }

        public void Delete(int id)
        {
            _exerciseDataAccess.Remove(id);
        }
    }
}
