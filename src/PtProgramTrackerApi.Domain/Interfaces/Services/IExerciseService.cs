using PtProgramTrackerApi.Domain.Dtos;
using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IExerciseService
    {
        Exercise GetById(int id);

        IEnumerable<Exercise> FindAll();

        Exercise Create(ExerciseDto input);

        Exercise Update(int id, ExerciseDto input);

        void Delete(int id);
    }
}
