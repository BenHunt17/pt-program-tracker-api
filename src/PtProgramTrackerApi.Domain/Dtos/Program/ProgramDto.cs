namespace PtProgramTrackerApi.Domain.Dtos.Program
{
    public class ProgramDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Aim { get; set; }

        public bool IsInClientContext { get; set; }
    }
}
