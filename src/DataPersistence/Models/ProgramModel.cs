using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtProgramTrackerApi.DataPersistence.Models
{
    public class ProgramModel : IDatabaseModel<Program>
    {
        public ProgramModel()
        {
        }

        public ProgramModel(ProgramDto program, int? clientId)
        { 
            Id = program.Id;
            Name = program.Name;
            Aim = program.Aim;

            if (program.IsInClientContext)
            {
                ClientId = clientId;
            }
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public string? Aim { get; set; }

        public ICollection<WorkoutModel> Workouts { get; set; }

        public int? ClientId { get; set; }
        public ClientModel? Client { get; set; }

        public Program ToDomainEntity()
        {
            return new Program
            {
                Id = Id,
                Name = Name,
                Aim = Aim,
                Workouts = Workouts.Select(
                    x => x.ToDomainEntity()),
                IsClientSpecific = ClientId != null,
            };
        }
    }
}
