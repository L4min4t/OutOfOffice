#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations.Application;

/// <inheritdoc />
public partial class AddEmployeeProjectManyToMany : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>
        (
            "Status",
            "Projects",
            "nvarchar(max)",
            nullable: false,
            defaultValue: "Active",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "ProjectType",
            "Projects",
            "nvarchar(max)",
            nullable: false,
            defaultValue: "Development",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "Projects",
            "nvarchar(500)",
            maxLength: 500,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "LeaveRequests",
            "nvarchar(500)",
            maxLength: 500,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Subdivision",
            "Employees",
            "nvarchar(max)",
            nullable: true,
            defaultValue: "IT",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Status",
            "Employees",
            "nvarchar(max)",
            nullable: false,
            defaultValue: "Active",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Position",
            "Employees",
            "nvarchar(max)",
            nullable: true,
            defaultValue: "Developer",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true
        );
        
        migrationBuilder.AlterColumn<int>
        (
            "OutOfOfficeBalance",
            "Employees",
            "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "FullName",
            "Employees",
            "nvarchar(200)",
            maxLength: 200,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "ApprovalRequests",
            "nvarchar(500)",
            maxLength: 500,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500
        );
        
        migrationBuilder.CreateTable
        (
            "EmployeeProjects",
            table => new
            {
                EmployeeId = table.Column<int>("int", nullable: false),
                ProjectId = table.Column<int>("int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey
                (
                    "PK_EmployeeProjects",
                    x => new { x.EmployeeId, x.ProjectId }
                );
                table.ForeignKey
                (
                    "FK_EmployeeProjects_Employees_EmployeeId",
                    x => x.EmployeeId,
                    "Employees",
                    "Id",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey
                (
                    "FK_EmployeeProjects_Projects_ProjectId",
                    x => x.ProjectId,
                    "Projects",
                    "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );
        
        migrationBuilder.CreateIndex
            ("IX_EmployeeProjects_ProjectId", "EmployeeProjects", "ProjectId");
    }
    
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("EmployeeProjects");
        
        migrationBuilder.AlterColumn<string>
        (
            "Status",
            "Projects",
            "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldDefaultValue: "Active"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "ProjectType",
            "Projects",
            "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldDefaultValue: "Development"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "Projects",
            "nvarchar(500)",
            maxLength: 500,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500,
            oldNullable: true
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "LeaveRequests",
            "nvarchar(500)",
            maxLength: 500,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500,
            oldNullable: true
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Subdivision",
            "Employees",
            "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true,
            oldDefaultValue: "IT"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Status",
            "Employees",
            "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldDefaultValue: "Active"
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Position",
            "Employees",
            "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true,
            oldDefaultValue: "Developer"
        );
        
        migrationBuilder.AlterColumn<int>
        (
            "OutOfOfficeBalance",
            "Employees",
            "int",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int",
            oldDefaultValue: 0
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "FullName",
            "Employees",
            "nvarchar(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(200)",
            oldMaxLength: 200
        );
        
        migrationBuilder.AlterColumn<string>
        (
            "Comment",
            "ApprovalRequests",
            "nvarchar(500)",
            maxLength: 500,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500,
            oldNullable: true
        );
    }
}
