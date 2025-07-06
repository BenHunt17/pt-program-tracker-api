using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtProgramTrackerApi.DataPersistence.Models
{
    public class WorkoutModel : IDatabaseModel<Workout>
    {
        public WorkoutModel()
        {
        }

        public WorkoutModel(int id)
        {
            Id = id;
        }

        public WorkoutModel(int programId, WorkoutDto workout)
        {
            Id = workout.Id;
            Name = workout.Name;
            ProgramId = programId;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public int ProgramId { get; set; }
        public ProgramModel Program { get; set; }

        public ICollection<ExerciseModel> Exercises { get; set; }

        public Workout ToDomainEntity()
        {
            return new Workout
            {
                Id = Id,
                Name = Name,
                Exercises = Exercises.Select(
                    x => x.ToDomainEntity()),
            };
        }
    }
}
