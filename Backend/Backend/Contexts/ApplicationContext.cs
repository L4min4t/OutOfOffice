using Backend.Lists;
using Backend.Lists.ApprovalRequests;
using Backend.Lists.Employees;
using Backend.Lists.LeaveRequests;
using Backend.Lists.Projects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>
        (
            entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200);
                
                entity.Property(e => e.Subdivision)
                    .HasDefaultValue(Subdivision.IT)
                    .HasConversion<string>();
                
                entity.Property(e => e.Position)
                    .HasDefaultValue(Position.Developer)
                    .HasConversion<string>();
                
                entity.Property(e => e.Status)
                    .HasDefaultValue(EmployeeStatus.Active)
                    .HasConversion<string>();
                
                entity.Property(e => e.OutOfOfficeBalance)
                    .HasDefaultValue(0);
                
                entity.Property(e => e.Photo)
                    .HasColumnType("varbinary(max)");
                
                entity.Property(e => e.PeoplePartnerId)
                    .IsRequired(false);
                
                entity.HasOne(e => e.PeoplePartner)
                    .WithMany()
                    .HasForeignKey(e => e.PeoplePartnerId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        );
        
        modelBuilder.Entity<LeaveRequest>
        (
            entity =>
            {
                entity.HasKey(l => l.Id);
                
                entity.Property(l => l.EmployeeId)
                    .IsRequired();
                
                entity.HasOne(l => l.Employee)
                    .WithMany()
                    .HasForeignKey(l => l.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.Property(l => l.AbsenceReason)
                    .IsRequired()
                    .HasConversion<string>();
                
                entity.Property(l => l.StartDate)
                    .IsRequired();
                
                entity.Property(l => l.EndDate)
                    .IsRequired();
                
                entity.Property(l => l.Comment)
                    .IsRequired(false)
                    .HasMaxLength(500);
                
                entity.Property(l => l.Status)
                    .IsRequired()
                    .HasDefaultValue(AbsenceRequestStatus.New)
                    .HasConversion<string>();
            }
        );
        
        modelBuilder.Entity<ApprovalRequest>
        (
            entity =>
            {
                entity.HasKey(a => a.Id);
                
                entity.Property(a => a.ApproverId)
                    .IsRequired();
                
                entity.HasOne(a => a.Approver)
                    .WithMany()
                    .HasForeignKey(a => a.ApproverId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.Property(a => a.LeaveRequestId)
                    .IsRequired();
                
                entity.HasOne(a => a.LeaveRequest)
                    .WithMany()
                    .HasForeignKey(a => a.LeaveRequestId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.Property(a => a.Status)
                    .IsRequired()
                    .HasDefaultValue(LeaveApprovalStatus.New)
                    .HasConversion<string>();
                
                entity.Property(a => a.Comment)
                    .IsRequired(false)
                    .HasMaxLength(500);
            }
        );
        
        modelBuilder.Entity<Project>
        (
            entity =>
            {
                entity.HasKey(p => p.Id);
                
                entity.Property(p => p.ProjectType)
                    .IsRequired()
                    .HasDefaultValue(ProjectType.Development)
                    .HasConversion<string>();
                
                entity.Property(p => p.StartDate)
                    .IsRequired();
                
                entity.Property(p => p.EndDate)
                    .IsRequired(false);
                
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
                    .IsRequired(false)
                    .HasMaxLength(500);
                
                entity.Property(p => p.Status)
                    .IsRequired()
                    .HasDefaultValue(ProjectStatus.Active)
                    .HasConversion<string>();
            }
        );
        
        modelBuilder.Entity<EmployeeProject>
        (
            entity =>
            {
                entity.HasKey(ep => ep.Id);
                
                entity.HasIndex(ep => new { ep.EmployeeId, ep.ProjectId });
                
                entity.HasOne(ep => ep.Employee)
                    .WithMany(e => e.EmployeeProjects)
                    .HasForeignKey(ep => ep.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(ep => ep.Project)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(ep => ep.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        );
    }
}
