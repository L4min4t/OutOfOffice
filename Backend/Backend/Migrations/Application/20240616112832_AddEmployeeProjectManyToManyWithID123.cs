#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations.Application;

/// <inheritdoc />
public partial class AddEmployeeProjectManyToManyWithID123 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey
            ("PK_EmployeeProjects", "EmployeeProjects");
        
        migrationBuilder.AddColumn<int>
            (
                "Id",
                "EmployeeProjects",
                "int",
                nullable: false,
                defaultValue: 0
            )
            .Annotation("SqlServer:Identity", "1, 1");
        
        migrationBuilder.AddPrimaryKey
            ("PK_EmployeeProjects", "EmployeeProjects", "Id");
        
        migrationBuilder.CreateIndex
        (
            "IX_EmployeeProjects_EmployeeId_ProjectId",
            "EmployeeProjects",
            new[] { "EmployeeId", "ProjectId" }
        );
    }
    
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey
            ("PK_EmployeeProjects", "EmployeeProjects");
        
        migrationBuilder.DropIndex
            ("IX_EmployeeProjects_EmployeeId_ProjectId", "EmployeeProjects");
        
        migrationBuilder.DropColumn("Id", "EmployeeProjects");
        
        migrationBuilder.AddPrimaryKey
        (
            "PK_EmployeeProjects",
            "EmployeeProjects",
            new[] { "EmployeeId", "ProjectId" }
        );
    }
}
