namespace PtProgramTrackerApi.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FitnessGoal { get; set; }

        public string? AdditionalNotes { get; set; }
    }
}
