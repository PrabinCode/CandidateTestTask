using CandidateTestTask.Modals;
using Microsoft.EntityFrameworkCore;

namespace CandidateTestTask.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique(); // Ensuring Email as unique identifier
        }
    }
}
