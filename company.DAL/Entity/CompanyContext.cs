using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using company.DAL.Repository.Models;

namespace company.DAL.Entity;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<bonuss> bonusses { get; set; }

    public virtual DbSet<employee> employees { get; set; }

    public virtual DbSet<employeesBonu> employeesBonus { get; set; }

    public virtual DbSet<employeesJob> employeesJobs { get; set; }

    public virtual DbSet<employeesVacation> employeesVacations { get; set; }

    public virtual DbSet<gender> genders { get; set; }

    public virtual DbSet<group> groups { get; set; }

    public virtual DbSet<icon> icons { get; set; }

    public virtual DbSet<job> jobs { get; set; }

    public virtual DbSet<page> pages { get; set; }

    public virtual DbSet<pagesGroup> pagesGroups { get; set; }

    public virtual DbSet<religion> religions { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<vacation> vacations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-GDRF01I;initial catalog=company;integrated security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_departments");
        });

        modelBuilder.Entity<employee>(entity =>
        {
            entity.HasOne(d => d.deprtment).WithMany(p => p.employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_Departments");

            entity.HasOne(d => d.gender).WithMany(p => p.employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_gender");

            entity.HasOne(d => d.religion).WithMany(p => p.employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_religions");
        });

        modelBuilder.Entity<employeesBonu>(entity =>
        {
            entity.HasOne(d => d.bonus).WithMany(p => p.employeesBonus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesBonus_bonuss");

            entity.HasOne(d => d.employee).WithMany(p => p.employeesBonus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesBonus_employees");
        });

        modelBuilder.Entity<employeesJob>(entity =>
        {
            entity.HasOne(d => d.employee).WithMany(p => p.employeesJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesJobs_employeesJobs");

            entity.HasOne(d => d.job).WithMany(p => p.employeesJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesJobs_employeesJobs1");
        });

        modelBuilder.Entity<employeesVacation>(entity =>
        {
            entity.HasOne(d => d.employee).WithMany(p => p.employeesVacations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesVacations_employees");

            entity.HasOne(d => d.vacation).WithMany(p => p.employeesVacations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesVacations_vacations");
        });

        modelBuilder.Entity<page>(entity =>
        {
            entity.HasOne(d => d.icon).WithMany(p => p.pages).HasConstraintName("FK_pages_icons");

            entity.HasOne(d => d.parent).WithMany(p => p.Inverseparent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pages_pages");
        });

        modelBuilder.Entity<pagesGroup>(entity =>
        {
            entity.HasOne(d => d.group).WithMany(p => p.pagesGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pagesGroups_groups");

            entity.HasOne(d => d.page).WithMany(p => p.pagesGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pagesGroups_pages");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.idNavigation).WithOne(p => p.user)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_employees");

            entity.HasOne(d => d.id1).WithOne(p => p.user)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_groups");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
