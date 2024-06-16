using Backend.Lists.Employees;
using Backend.Lists.Projects;
using Backend.Repositories.Interfaces;

namespace Backend.Lists;

public class EmployeeProject : IEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int Id { get; set; }
}