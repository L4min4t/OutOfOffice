using System.Linq.Expressions;
using Backend.Lists;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Servises.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Backend.Servises.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly UserManager<User> _userManager;
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository, UserManager<User> userManager) : base(repository)
    {
        _userManager = userManager;
        _repository = repository;
    }
    
    public virtual async Task<List<Employee>?> FindByConditionAsync(Expression<Func<Employee, bool>> expression)
    {
        try
        {
            var entities = await _repository.FindByConditionAsync(expression);
            if (entities.Any())
            {
                return entities;
            }

            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}