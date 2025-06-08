using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Inputs
{
    public class ClientInput
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FitnessGoal { get; set; }

        public string? AdditionalNotes { get; set; }

        public Client ToDomainEntity()
        {
            return new Client
            {
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
