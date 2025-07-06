using Microsoft.EntityFrameworkCore;
using PtProgramTrackerApi.DataPersistence.Models;
using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;

namespace PtProgramTrackerApi.DataPersistence.DataAccess
{
    public class ProgramDataAccess : IProgramDataAccess
    {
        private readonly DataContext _dataContext;

        public ProgramDataAccess(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Program GetById(int id)
        {
            return GetProgramById(id).ToDomainEntity();
        }

        public IEnumerable<Program> FindAll()
        {
            return _dataContext.Programs
                .Include(x => x.Workouts)
                .ThenInclude(x => x.Exercises)
                .AsNoTracking()
                .Select(x => x.ToDomainEntity())
                .ToList();
        }

        public Program UpsertProgram(ProgramDto input)
        {
            var programModel = new ProgramModel(input);

            if (programModel.Id == 0)
            {
                _dataContext.Add(programModel);
            }
            else
            {
                _dataContext.Attach(programModel);
                _dataContext.Entry(programModel).State = EntityState.Modified;
            }

            _dataContext.SaveChanges();

            return GetById(programModel.Id);
        }

        public Program UpsertProgramWorkout(int programId, WorkoutDto input)
        {
            var workoutModel = new WorkoutModel(programId, input);

            if (workoutModel.Id == 0)
            {
                _dataContext.Add(workoutModel);
            }
            else
            {
                _dataContext.Attach(workoutModel);
                _dataContext.Entry(workoutModel).State = EntityState.Modified;
            }

            _dataContext.SaveChanges();

            return GetById(programId);
        }

        public Program RemoveProgramWorkout(int programId, int workoutId)
        {
            var workoutModel = new WorkoutModel(workoutId);
            _dataContext.Attach(workoutModel);

            _dataContext.Remove(workoutModel);

            _dataContext.SaveChanges();

            return GetById(programId);
        }

        public Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds)
        {
            var workoutModel = _dataContext.Workouts
                .Include(x => x.Exercises)
                .FirstOrDefault(x => x.Id == workoutId && x.ProgramId == programId);

            var exerciseModels = _dataContext.Exercises
                .Where(x => exerciseIds.Contains(x.Id))
                .ToList();

            if (workoutModel == null)
            {
                throw new KeyNotFoundException("Workout not found");
            }

            var toAdd = exerciseModels
                .Where(x => !workoutModel.Exercises.Any(xx => xx.Id == x.Id));

            // Exercises are independent entities and should not be inserted/updated.
            _dataContext.AttachRange(toAdd);

            foreach (var exerciseModel in toAdd)
            {
                workoutModel.Exercises.Add(exerciseModel);
            }

            var toRemove = workoutModel.Exercises.Where(x => !exerciseModels.Any(xx => xx.Id == x.Id));

            foreach (var exerciseModel in toRemove)
            {
                workoutModel.Exercises.Remove(exerciseModel);
            }

            _dataContext.SaveChanges();

            return GetById(programId);
        }

        public void RemoveProgram(int id)
        {
            var programModel = GetProgramById(id);

            _dataContext.Remove(programModel);

            _dataContext.SaveChanges();
        }

        private ProgramModel GetProgramById(int id)
        {
            var program = _dataContext.Programs
                .Include(x => x.Workouts)
                .ThenInclude(x => x.Exercises)
                .FirstOrDefault();

            if (program == null)
            {
                throw new KeyNotFoundException($"No program with ID {id} was found");
            }

            return program;
        }
    }
}
