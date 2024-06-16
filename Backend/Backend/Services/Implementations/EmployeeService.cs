using AutoMapper;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repository;
    
    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Result<Employee>> CreateAsync(CreateEmployeeDto dto)
    {
        var project = _mapper.Map<Employee>(dto);
        try
        {
            await _repository.CreateAsync(project);
            
            return Result.Success(project);
        }
        catch (Exception)
        {
            return Result<Employee>.Fail("Failed to create employee!");
        }
    }
}