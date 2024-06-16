using Backend.Contexts;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context)
        : base(context)
    {
    }
}