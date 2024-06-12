using Backend.Lists;
using Backend.Lists.ApprovalRequests;
using Backend.Lists.Employees;
using Backend.Lists.LeaveRequests;
using Backend.Lists.Projects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    public DbSet<Project> Projects { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Subdivision)
                .IsRequired()
                .HasConversion<string>();

            entity.Property(e => e.Position)
                .IsRequired()
                .HasConversion<string>();

            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>();

            entity.Property(e => e.OutOfOfficeBalance)
                .IsRequired();

            entity.Property(e => e.Photo)
                .HasColumnType("varbinary(max)");

            entity.HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.EmployeeId)
                .IsRequired();

            entity.HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(a => a.AbsenceReason)
                .IsRequired()
                .HasConversion<string>();

            entity.Property(a => a.StartDate)
                .IsRequired();

            entity.Property(a => a.EndDate)
                .IsRequired();

            entity.Property(a => a.Comment)
                .HasMaxLength(500);

            entity.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(AbsenceRequestStatus.New)
                .HasConversion<string>();
        });

        modelBuilder.Entity<ApprovalRequest>(entity =>
        {
            entity.HasKey(l => l.Id);

            entity.Property(l => l.ApproverId)
                .IsRequired();

            entity.HasOne(l => l.Approver)
                .WithMany()
                .HasForeignKey(l => l.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(l => l.LeaveRequestId)
                .IsRequired();

            entity.HasOne(l => l.LeaveRequest)
                .WithMany()
                .HasForeignKey(l => l.LeaveRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(l => l.Status)
                .IsRequired()
                .HasDefaultValue(LeaveApprovalStatus.New)
                .HasConversion<string>();

            entity.Property(l => l.Comment)
                .HasMaxLength(500);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.ProjectType)
                .IsRequired()
                .HasConversion<string>();

            entity.Property(p => p.StartDate)
                .IsRequired();

            entity.Property(p => p.EndDate);

            entity.Property(p => p.ProjectManagerId)
                .IsRequired();

            entity.HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Project_ProjectManager")
                .HasForeignKey(e => e.ProjectManagerId)
                .IsRequired();

            entity.Property(p => p.Comment)
                .HasMaxLength(500);

            entity.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>();
        });
    }
}