using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtProgramTrackerApi.DataPersistence.Models
{
    public class ProgramModel : IDatabaseModel<Program>
    {
        public ProgramModel()
        {
        }

        public ProgramModel(ProgramInput program)
        { 
            Id = program.Id;
            Name = program.Name;
            Aim = program.Aim;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public string? Aim { get; set; }

        public ICollection<WorkoutModel> Workouts { get; set; }

        public Program ToDomainEntity()
        {
            return new Program
            {
                Id = Id,
                Name = Name,
                Aim = Aim,
                Workouts = Workouts.Select(
                    x => x.ToDomainEntity())
            };
        }
    }
}
