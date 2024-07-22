using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess.Entities;

public partial class EmployeeDbContext : IdentityDbContext<AppUser>
{

    //public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
    //    : base(options)
    //{
    //}

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleDetail> RoleDetails { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TL196;Initial Catalog=EmployeeApplicationDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        List<IdentityRole>roles=new List<IdentityRole>
        {
            new IdentityRole
            {
                Name="Admin",
                NormalizedName="ADMIN"
            },
            new IdentityRole
            {
                Name="User",
                NormalizedName="USER"
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD476A6D2C");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF11C366114");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeProfilePic).IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.JoiningDate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ManagerID");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.RoleDetailId).HasColumnName("RoleDetailID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Employees__Manag__45F365D3");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Employees__Proje__46E78A0C");

            entity.HasOne(d => d.RoleDetail).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__RoleD__44FF419A");

            entity.HasOne(d => d.Status).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Employees__Statu__47DBAE45");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477DF59278D");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED078DC903A");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A841C35E8");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleDetail>(entity =>
        {
            entity.HasKey(e => e.RoleDetailId).HasName("PK__RoleDeta__6ED36410ECFC0043");

            entity.Property(e => e.RoleDetailId).HasColumnName("RoleDetailID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Department).WithMany(p => p.RoleDetails)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoleDetai__Depar__412EB0B6");

            entity.HasOne(d => d.Location).WithMany(p => p.RoleDetails)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoleDetai__Locat__4222D4EF");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleDetails)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoleDetai__RoleI__403A8C7D");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043CA398F39");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusValue)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
