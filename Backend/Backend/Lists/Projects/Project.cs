using Backend.Enums;
using Backend.Lists.Employees;

namespace Backend.Lists.Projects;

public class Project
{
    public int Id { get; set; }

    public ProjectType ProjectType { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int ProjectManagerId { get; set; }
    public Employee ProjectManager { get; set; }

    public string Comment { get; set; }

    public ProjectStatus Status { get; set; }
}