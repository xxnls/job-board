﻿// <auto-generated />
using System;
using JobBoard.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobBoard.API.Migrations
{
    [DbContext(typeof(JobBoardDbContext))]
    partial class JobBoardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyLocation", b =>
                {
                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("CompanyId", "LocationId")
                        .HasName("PK__CompanyL__43E8F6E5601174FD");

                    b.HasIndex("LocationId");

                    b.ToTable("CompanyLocations", (string)null);
                });

            modelBuilder.Entity("JobBoard.API.Models.Application", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<long>("JobId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("SubmittedResumeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__Applicat__3214EC077FAC1F27");

                    b.HasIndex("JobId");

                    b.HasIndex("PersonId");

                    b.HasIndex(new[] { "SubmittedResumeId" }, "UQ__Applicat__D25436FDE2B673B8")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobBoard.API.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PK__Categori__3214EC07749318E1");

                    b.HasIndex(new[] { "Name" }, "UQ__Categori__737584F650B7E267")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JobBoard.API.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasName("PK__Companie__3214EC0773333DF1");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobBoard.API.Models.Job", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("ContractType")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("WorkModel")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id")
                        .HasName("PK__Jobs__3214EC07B810A348");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobBoard.API.Models.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PK__Location__3214EC07B22580C0");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("JobBoard.API.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__People__3214EC073902FC7D");

                    b.HasIndex("LocationId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("JobBoard.API.Models.Resume", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__Resumes__3214EC0746DC3179");

                    b.HasIndex(new[] { "PersonId" }, "UQ__Resumes__AA2FFBE454C1BD2F")
                        .IsUnique();

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobBoard.API.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC0715414D41");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534E0285363")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobCategory", b =>
                {
                    b.Property<long>("JobId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("JobId", "CategoryId")
                        .HasName("PK__JobCateg__A4F6036265FA1688");

                    b.HasIndex("CategoryId");

                    b.ToTable("JobCategories", (string)null);
                });

            modelBuilder.Entity("JobLocation", b =>
                {
                    b.Property<long>("JobId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("JobId", "LocationId")
                        .HasName("PK__JobLocat__6B197A8BC81DBA76");

                    b.HasIndex("LocationId");

                    b.ToTable("JobLocations", (string)null);
                });

            modelBuilder.Entity("CompanyLocation", b =>
                {
                    b.HasOne("JobBoard.API.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__CompanyLo__Compa__0E6E26BF");

                    b.HasOne("JobBoard.API.Models.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK__CompanyLo__Locat__0F624AF8");
                });

            modelBuilder.Entity("JobBoard.API.Models.Application", b =>
                {
                    b.HasOne("JobBoard.API.Models.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK__Applicati__JobId__04E4BC85");

                    b.HasOne("JobBoard.API.Models.Person", "Person")
                        .WithMany("Applications")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK__Applicati__Perso__03F0984C");

                    b.HasOne("JobBoard.API.Models.Resume", "SubmittedResume")
                        .WithOne("Application")
                        .HasForeignKey("JobBoard.API.Models.Application", "SubmittedResumeId")
                        .IsRequired()
                        .HasConstraintName("FK__Applicati__Submi__05D8E0BE");

                    b.Navigation("Job");

                    b.Navigation("Person");

                    b.Navigation("SubmittedResume");
                });

            modelBuilder.Entity("JobBoard.API.Models.Company", b =>
                {
                    b.HasOne("JobBoard.API.Models.User", "IdNavigation")
                        .WithOne("Company")
                        .HasForeignKey("JobBoard.API.Models.Company", "Id")
                        .IsRequired()
                        .HasConstraintName("FK__Companies__Id__628FA481");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("JobBoard.API.Models.Job", b =>
                {
                    b.HasOne("JobBoard.API.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Jobs__CompanyId__797309D9");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobBoard.API.Models.Person", b =>
                {
                    b.HasOne("JobBoard.API.Models.User", "IdNavigation")
                        .WithOne("Person")
                        .HasForeignKey("JobBoard.API.Models.Person", "Id")
                        .IsRequired()
                        .HasConstraintName("FK__People__Id__6B24EA82");

                    b.HasOne("JobBoard.API.Models.Location", "Location")
                        .WithMany("People")
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK__People__Location__6D0D32F4");

                    b.Navigation("IdNavigation");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("JobBoard.API.Models.Resume", b =>
                {
                    b.HasOne("JobBoard.API.Models.Person", "Person")
                        .WithOne("Resume")
                        .HasForeignKey("JobBoard.API.Models.Resume", "PersonId")
                        .IsRequired()
                        .HasConstraintName("FK__Resumes__PersonI__72C60C4A");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("JobCategory", b =>
                {
                    b.HasOne("JobBoard.API.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__JobCatego__Categ__0B91BA14");

                    b.HasOne("JobBoard.API.Models.Job", null)
                        .WithMany()
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK__JobCatego__JobId__0A9D95DB");
                });

            modelBuilder.Entity("JobLocation", b =>
                {
                    b.HasOne("JobBoard.API.Models.Job", null)
                        .WithMany()
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK__JobLocati__JobId__123EB7A3");

                    b.HasOne("JobBoard.API.Models.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK__JobLocati__Locat__1332DBDC");
                });

            modelBuilder.Entity("JobBoard.API.Models.Company", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoard.API.Models.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("JobBoard.API.Models.Location", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("JobBoard.API.Models.Person", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("JobBoard.API.Models.Resume", b =>
                {
                    b.Navigation("Application");
                });

            modelBuilder.Entity("JobBoard.API.Models.User", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
