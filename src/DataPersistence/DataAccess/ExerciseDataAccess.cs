using Microsoft.EntityFrameworkCore;
using PtProgramTrackerApi.DataPersistence.Models;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;

namespace PtProgramTrackerApi.DataPersistence.DataAccess
{
    public class ExerciseDataAccess : IExerciseDataAccess
    {
        private readonly DataContext _dataContext;

        public ExerciseDataAccess(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Exercise GetById(int id)
        {
            return GetExerciseById(id).ToDomainEntity();
        }

        public IEnumerable<Exercise> FindAll()
        {
            return _dataContext.Exercises
                .AsNoTracking()
                .Select(x => x.ToDomainEntity())
                .ToList();
        }

        public Exercise Add(Exercise exercise)
        {
            var exerciseToAdd = new ExerciseModel(exercise);

            _dataContext.Exercises.Add(exerciseToAdd);

            _dataContext.SaveChanges();

            return exerciseToAdd.ToDomainEntity();
        }

        public Exercise Update(int id, Exercise exercise)
        {
            var exerciseToUpdate = GetExerciseById(id);

            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.Type = exercise.Type;

            _dataContext.SaveChanges();

            return exerciseToUpdate.ToDomainEntity();
        }

        public void Remove(int id)
        {
            var exerciseToRemove = GetExerciseById(id);

            _dataContext.Exercises.Remove(exerciseToRemove);

            _dataContext.SaveChanges();
        }

        private ExerciseModel GetExerciseById(int id)
        {
            var exercise = _dataContext.Exercises
                .FirstOrDefault(x => x.Id == id);

            if (exercise == null)
            {
                throw new KeyNotFoundException($"No exercise with ID {id} was found");
            }

            return exercise;
        }
    }
}
