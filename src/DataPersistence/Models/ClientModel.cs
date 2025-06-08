using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtProgramTrackerApi.DataPersistence.Models
{
    public class ClientModel : IDatabaseModel<Client>
    {
        public ClientModel() { }

        public ClientModel(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            DateOfBirth = client.DateOfBirth;
            Height = client.Height;
            Weight = client.Weight;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            FitnessGoal = client.FitnessGoal;
            AdditionalNotes = client.AdditionalNotes;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }

        public string? Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? PhoneNumber { get; set; }

        public string? FitnessGoal { get; set; }

        public string? AdditionalNotes { get; set; }

        public Client ToDomainEntity()
        {
            return new Client
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Height = Height,
                Weight = Weight,
                Email = Email,
                PhoneNumber = PhoneNumber,
                FitnessGoal = FitnessGoal,
                AdditionalNotes = AdditionalNotes
            };
        }
    }
}
