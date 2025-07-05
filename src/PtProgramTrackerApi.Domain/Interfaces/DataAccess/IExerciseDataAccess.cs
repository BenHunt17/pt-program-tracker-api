using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.DataAccess
{
    public interface IExerciseDataAccess
    {
        Exercise GetById(int id);

        IEnumerable<Exercise> FindAll();

        Exercise Add(Exercise input);

        Exercise Update(int id, Exercise input);

        void Remove(int id);
    }
}
