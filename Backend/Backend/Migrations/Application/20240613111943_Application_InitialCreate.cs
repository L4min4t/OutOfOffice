#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations.Application;

/// <inheritdoc />
public partial class Application_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Employees",
            table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                FullName = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Subdivision = table.Column<string>("nvarchar(max)", nullable: true),
                Position = table.Column<string>("nvarchar(max)", nullable: true),
                Status = table.Column<string>("nvarchar(max)", nullable: false),
                PeoplePartnerId = table.Column<int>("int", nullable: true),
                OutOfOfficeBalance = table.Column<int>("int", nullable: false),
                Photo = table.Column<byte[]>("varbinary(max)", nullable: true),
                IdentityId = table.Column<string>("nvarchar(max)", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    "FK_Employees_Employees_PeoplePartnerId", x => x.PeoplePartnerId, "Employees", "Id",
                    onDelete: ReferentialAction.Restrict
                );
            }
        );
        
        migrationBuilder.CreateTable(
            "LeaveRequests",
            table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                EmployeeId = table.Column<int>("int", nullable: false),
                AbsenceReason = table.Column<string>("nvarchar(max)", nullable: false),
                StartDate = table.Column<DateTime>("datetime2", nullable: false),
                EndDate = table.Column<DateTime>("datetime2", nullable: false),
                Comment = table.Column<string>("nvarchar(500)", maxLength: 500, nullable: false),
                Status = table.Column<string>("nvarchar(max)", nullable: false, defaultValue: "New")
            }, constraints: table =>
            {
                table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                table.ForeignKey(
                    "FK_LeaveRequests_Employees_EmployeeId", x => x.EmployeeId, "Employees", "Id",
                    onDelete: ReferentialAction.Restrict
                );
            }
        );
        
        migrationBuilder.CreateTable(
            "Projects",
            table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ProjectType = table.Column<string>("nvarchar(max)", nullable: false),
                StartDate = table.Column<DateTime>("datetime2", nullable: false),
                EndDate = table.Column<DateTime>("datetime2", nullable: true),
                ProjectManagerId = table.Column<int>("int", nullable: false),
                Comment = table.Column<string>("nvarchar(500)", maxLength: 500, nullable: false),
                Status = table.Column<string>("nvarchar(max)", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Projects", x => x.Id);
                table.ForeignKey(
                    "FK_Project_ProjectManager", x => x.ProjectManagerId, "Employees", "Id",
                    onDelete: ReferentialAction.Restrict
                );
            }
        );
        
        migrationBuilder.CreateTable(
            "ApprovalRequests",
            table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ApproverId = table.Column<int>("int", nullable: false),
                LeaveRequestId = table.Column<int>("int", nullable: false),
                Status = table.Column<string>("nvarchar(max)", nullable: false, defaultValue: "New"),
                Comment = table.Column<string>("nvarchar(500)", maxLength: 500, nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_ApprovalRequests", x => x.Id);
                table.ForeignKey(
                    "FK_ApprovalRequests_Employees_ApproverId", x => x.ApproverId, "Employees", "Id",
                    onDelete: ReferentialAction.Restrict
                );
                table.ForeignKey(
                    "FK_ApprovalRequests_LeaveRequests_LeaveRequestId", x => x.LeaveRequestId, "LeaveRequests", "Id",
                    onDelete: ReferentialAction.Restrict
                );
            }
        );
        
        migrationBuilder.CreateIndex("IX_ApprovalRequests_ApproverId", "ApprovalRequests", "ApproverId");
        
        migrationBuilder.CreateIndex("IX_ApprovalRequests_LeaveRequestId", "ApprovalRequests", "LeaveRequestId");
        
        migrationBuilder.CreateIndex("IX_Employees_PeoplePartnerId", "Employees", "PeoplePartnerId");
        
        migrationBuilder.CreateIndex("IX_LeaveRequests_EmployeeId", "LeaveRequests", "EmployeeId");
        
        migrationBuilder.CreateIndex("IX_Projects_ProjectManagerId", "Projects", "ProjectManagerId");
    }
    
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("ApprovalRequests");
        
        migrationBuilder.DropTable("Projects");
        
        migrationBuilder.DropTable("LeaveRequests");
        
        migrationBuilder.DropTable("Employees");
    }
}