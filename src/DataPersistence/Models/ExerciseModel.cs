using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtProgramTrackerApi.DataPersistence.Models
{
    public class ExerciseModel : IDatabaseModel<Exercise>
    {
        public ExerciseModel()
        {
        }

        public ExerciseModel(int id)
        {
            Id = id;
        }

        public ExerciseModel(Exercise exercise)
        {
            Name = exercise.Name;
            Type = exercise.Type;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public ExerciseType Type { get; set; }

        public ICollection<WorkoutModel> Workouts { get; set; }

        public Exercise ToDomainEntity()
        {
            return new Exercise
            {
                Id = Id,
                Name = Name,
                Type = Type,
            };
        }
    }
}
