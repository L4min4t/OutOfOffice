using Backend.Lists;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class EmployeeProjectService
    : BaseService<EmployeeProject>, IEmployeeProjectService
{
    private readonly IEmployeeProjectRepository _repository;
    
    public EmployeeProjectService(IEmployeeProjectRepository repository)
        : base(repository)
    {
        _repository = repository;
    }
    
    public async Task HandleProjectsListAsync
        (int employeeId, List<int> projectsList)
    {
        var list = await _repository.FindByConditionAsync
            (ep => ep.EmployeeId == employeeId);
        foreach (var row in list)
            if (projectsList.Contains
                    (row.ProjectId)) projectsList.Remove(row.ProjectId);
            else await _repository.DeleteAsync(row);
        
        if (projectsList.Any())
            foreach (var id in projectsList)
                await _repository.CreateAsync
                (
                    new EmployeeProject
                    {
                        ProjectId = id,
                        EmployeeId = employeeId
                    }
                );
    }
}
