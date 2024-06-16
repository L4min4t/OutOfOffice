using AutoMapper;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly IEmployeeProjectService _employeeProjectService;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repository;
    
    public EmployeeService
    (
        IEmployeeRepository repository,
        IMapper mapper,
        IEmployeeProjectService employeeProjectService
    )
        : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
        _employeeProjectService = employeeProjectService;
    }
    
    public new async Task<Result<EmployeeDto?>> FindByIdAsync(int id)
    {
        return _mapper.Map<EmployeeDto>(await _repository.FindByIdAsync(id));
    }
    
    public async Task<Result<EmployeeDto>> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        try
        {
            await _repository.CreateAsync(employee);
            
            return Result.Success(_mapper.Map<EmployeeDto>(employee));
        }
        catch (Exception)
        {
            return Result<EmployeeDto>.Fail("Failed to create employee!");
        }
    }
    
    public async Task<Result<EmployeeDto>> UpdateAsync(UpdateEmployeeDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        
        try
        {
            await _repository.UpdateAsync(employee);
            await _employeeProjectService.HandleProjectsListAsync
                (dto.Id, dto.ProjectIds);
            
            return Result.Success
            (
                _mapper.Map<EmployeeDto>
                    (await _repository.FindByIdAsync(dto.Id))
            );
        }
        catch (Exception)
        {
            return Result<EmployeeDto>.Fail("Failed to update employee!");
        }
    }
}
