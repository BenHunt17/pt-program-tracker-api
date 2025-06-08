namespace PtProgramTrackerApi.DataPersistence.Models
{
    public interface IDatabaseModel<T>
    {
        public int Id { get; set; }

        public T ToDomainEntity();
    }
}
