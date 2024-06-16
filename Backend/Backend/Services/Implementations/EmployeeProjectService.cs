using Backend.Lists;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class EmployeeProjectService : BaseService<EmployeeProject>, IEmployeeProjectService
{
    public EmployeeProjectService(IEmployeeProjectRepository repository)
        : base(repository)
    {
    }
}