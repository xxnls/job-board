using System;
using System.Collections.Generic;
using JobBoard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.API.Data;

public partial class JobBoardDbContext : DbContext
{
    public JobBoardDbContext()
    {
    }

    public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=rosiek.database.windows.net;Database=JobBoardDB;User Id=rosiek;Password=Bartek112233;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC077FAC1F27");

            entity.HasIndex(e => e.SubmittedResumeId, "UQ__Applicat__D25436FDE2B673B8").IsUnique();

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Job).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__JobId__04E4BC85");

            entity.HasOne(d => d.Person).WithMany(p => p.Applications)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Perso__03F0984C");

            entity.HasOne(d => d.SubmittedResume).WithOne(p => p.Application)
                .HasForeignKey<Application>(d => d.SubmittedResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Submi__05D8E0BE");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07749318E1");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F650B7E267").IsUnique();

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC0773333DF1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(256);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Companies__Id__628FA481");

            entity.HasMany(d => d.Locations).WithMany(p => p.Companies)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyLocation",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CompanyLo__Locat__0F624AF8"),
                    l => l.HasOne<Company>().WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CompanyLo__Compa__0E6E26BF"),
                    j =>
                    {
                        j.HasKey("CompanyId", "LocationId").HasName("PK__CompanyL__43E8F6E5601174FD");
                        j.ToTable("CompanyLocations");
                    });
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jobs__3214EC07B810A348");

            entity.Property(e => e.ContractType).HasMaxLength(16);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(256);
            entity.Property(e => e.WorkModel).HasMaxLength(16);

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__CompanyId__797309D9");

            entity.HasMany(d => d.Categories).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__JobCatego__Categ__0B91BA14"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__JobCatego__JobId__0A9D95DB"),
                    j =>
                    {
                        j.HasKey("JobId", "CategoryId").HasName("PK__JobCateg__A4F6036265FA1688");
                        j.ToTable("JobCategories");
                    });

            entity.HasMany(d => d.Locations).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobLocation",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__JobLocati__Locat__1332DBDC"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__JobLocati__JobId__123EB7A3"),
                    j =>
                    {
                        j.HasKey("JobId", "LocationId").HasName("PK__JobLocat__6B197A8BC81DBA76");
                        j.ToTable("JobLocations");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07B22580C0");

            entity.Property(e => e.City).HasMaxLength(256);
            entity.Property(e => e.Country).HasMaxLength(256);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PostalCode).HasMaxLength(16);
            entity.Property(e => e.Region).HasMaxLength(256);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC073902FC7D");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.Gender).HasMaxLength(16);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(256);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__People__Id__6B24EA82");

            entity.HasOne(d => d.Location).WithMany(p => p.People)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__People__Location__6D0D32F4");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resumes__3214EC0746DC3179");

            entity.HasIndex(e => e.PersonId, "UQ__Resumes__AA2FFBE454C1BD2F").IsUnique();

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Person).WithOne(p => p.Resume)
                .HasForeignKey<Resume>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resumes__PersonI__72C60C4A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0715414D41");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E0285363").IsUnique();

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.PhoneNumber).HasMaxLength(32);
            entity.Property(e => e.UserType).HasMaxLength(16);
            entity.Property(e => e.Username).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
