using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IExerciseService
    {
        Exercise GetById(int id);

        IEnumerable<Exercise> FindAll();

        Exercise Create(ExerciseInput input);

        Exercise Update(int id, ExerciseInput input);

        void Delete(int id);
    }
}
