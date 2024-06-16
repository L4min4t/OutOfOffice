using Backend.Lists;

namespace Backend.Services.Interfaces;

public interface IEmployeeProjectService : IBaseService<EmployeeProject>
{
    Task HandleProjectsListAsync(int employeeId, List<int> projectsList);
}
