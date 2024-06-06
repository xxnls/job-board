using JobBoard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.API.Data  // Place this in a "Data" folder
{
    public class JobBoardDbContext : DbContext
    {
        public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Application> Applications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasMany(j => j.JobCategories);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Locations);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Applications)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobId);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Locations);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Resume);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Location);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Applications)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.SubmittedResume);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job);

            // Table-Per-Hierarchy Inheritance for User
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Company>("Company")
                .HasValue<Person>("Person");
        }
    }
}
