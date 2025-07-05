using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PtProgramTrackerApi.DataPersistence.Models;

namespace PtProgramTrackerApi.DataPersistence
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ClientModel> Clients { get; set; }

        public DbSet<ProgramModel> Programs { get; set; }

        public DbSet<WorkoutModel> Workouts { get; set; }

        public DbSet<ExerciseModel> Exercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PtProgramTrackerDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramModel>()
                .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<ExerciseModel>()
                .HasIndex(x => x.Name).IsUnique();
        }
    }
}
