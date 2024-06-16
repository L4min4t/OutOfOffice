using Backend.Lists.Employees;

namespace Backend.Lists.Projects;

public class Project : IEntity
{
    public ProjectType ProjectType { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public int ProjectManagerId { get; set; }
    public Employee ProjectManager { get; set; }
    
    public string Comment { get; set; }
    
    public ProjectStatus Status { get; set; }
    
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    public int Id { get; set; }
}

public enum ProjectStatus
{
    Active,
    Inactive
}

public enum ProjectType
{
    Internal,
    External,
    Research,
    Development,
    Maintenance
}