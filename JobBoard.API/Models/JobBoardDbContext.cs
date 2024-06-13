using Microsoft.EntityFrameworkCore;

namespace JobBoard.API.Models
{
    public class JobBoardDbContext : DbContext
    {
        public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<JobLocation> JobLocations { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // JobLocation
            modelBuilder.Entity<JobLocation>()
                .HasKey(jl => new { jl.JobId, jl.LocationId });

            modelBuilder.Entity<JobLocation>()
                .HasOne(jl => jl.Job)
                .WithMany(j => j.JobLocations)
                .HasForeignKey(jl => jl.JobId);

            modelBuilder.Entity<JobLocation>()
                .HasOne(jl => jl.Location)
                .WithMany(l => l.JobLocations)
                .HasForeignKey(jl => jl.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // JobCategory
            modelBuilder.Entity<JobCategory>()
                .HasKey(jc => new { jc.JobId, jc.CategoryId });

            modelBuilder.Entity<JobCategory>()
                .HasOne(jc => jc.Job)
                .WithMany(j => j.JobCategories)
                .HasForeignKey(jc => jc.JobId);

            modelBuilder.Entity<JobCategory>()
                .HasOne(jc => jc.Category)
                .WithMany(c => c.JobCategories)
                .HasForeignKey(jc => jc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // CompanyLocation
            modelBuilder.Entity<CompanyLocation>()
                .HasKey(cl => new { cl.CompanyId, cl.LocationId });

            modelBuilder.Entity<CompanyLocation>()
                .HasOne(c => c.Company)
                .WithMany(c => c.CompanyLocations)
                .HasForeignKey(cl => cl.CompanyId);

            modelBuilder.Entity<CompanyLocation>()
                .HasOne(cl => cl.Location)
                .WithMany(l => l.CompanyLocations)
                .HasForeignKey(cl => cl.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // Job
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Company
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Person
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Location)
                .WithMany()
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
