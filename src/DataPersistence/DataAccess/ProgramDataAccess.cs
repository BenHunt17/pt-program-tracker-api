using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using PtProgramTrackerApi.DataPersistence.Models;
using PtProgramTrackerApi.DataPersistence.QueryExtensions;
using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;

namespace PtProgramTrackerApi.DataPersistence.DataAccess
{
    public class ProgramDataAccess : IProgramDataAccess
    {
        private readonly DataContext _dataContext;
        private readonly IRequestContext _requestContext;

        public ProgramDataAccess(DataContext dataContext, IRequestContext requestContext)
        {
            _dataContext = dataContext;
            _requestContext = requestContext;
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
                .WithClientFilter(_requestContext.ClientId)
                .Select(x => x.ToDomainEntity())
                .ToList();
        }

        public Program UpsertProgram(ProgramDto input)
        {
            ProgramModel programModel;

            if (input.Id != 0)
            {
                programModel = GetProgramById(input.Id); 
                programModel.Name = input.Name;
                programModel.Aim = input.Aim;

                if (input.IsInClientContext)
                {
                    programModel.ClientId = _requestContext.ClientId;
                }
            }
            else
            {
                programModel = new ProgramModel(input, _requestContext.ClientId);
                _dataContext.Add(programModel);
            }

            _dataContext.SaveChanges();

            return GetById(programModel.Id);
        }

        public Program UpsertProgramWorkout(int programId, WorkoutDto input)
        {
            var programModel = GetProgramById(programId);

            if (input.Id == 0)
            {
                var workoutModel = new WorkoutModel(programId, input);
                _dataContext.Add(workoutModel);
            }
            else
            {
                var workoutModel = programModel.Workouts.FirstOrDefault(x => x.Id == input.Id);

                if (workoutModel != null)
                {
                    workoutModel.Name = input.Name;
                }
            }

            _dataContext.SaveChanges();

            return GetById(programId);
        }

        public Program RemoveProgramWorkout(int programId, int workoutId)
        {
            var programModel = GetProgramById(programId);

            var workoutModel = programModel.Workouts.FirstOrDefault(x => x.Id ==  workoutId);

            if (workoutModel != null)
            {
                _dataContext.Remove(workoutModel);
            }

            _dataContext.SaveChanges();

            return GetById(programId);
        }

        public Program UpdateProgramWorkoutExercises(int programId, int workoutId, IEnumerable<int> exerciseIds)
        {
            GetProgramById(programId);

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
                .WithClientFilter(_requestContext.ClientId)
                .FirstOrDefault(x => x.Id == id);

            if (program == null)
            {
                throw new KeyNotFoundException($"No program with ID {id} was found");
            }

            return program;
        }
    }
}
