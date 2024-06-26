using Backend.Contexts;
using Backend.Lists;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations;

public class EmployeeProjectRepository
    : BaseRepository<EmployeeProject>, IEmployeeProjectRepository
{
    public EmployeeProjectRepository(ApplicationContext context)
        : base(context)
    {
    }
}
