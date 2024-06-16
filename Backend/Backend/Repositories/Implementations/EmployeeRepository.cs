using Backend.Contexts;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Implementations;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context)
        : base(context)
    {
    }
    
    public override async Task<Employee?> FindByIdAsync(int id)
    {
        return await DbSet.Include(e => e.PeoplePartner)
            .Include(e => e.EmployeeProjects)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
