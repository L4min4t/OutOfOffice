using AutoMapper;
using Backend.Lists.Projects;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class ProjectService : BaseService<Project>, IProjectService
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _repository;
    
    public ProjectService(IProjectRepository repository, IMapper mapper)
        : base(repository)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Result<Project>> CreateAsync(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);
        try
        {
            await _repository.CreateAsync(project);
            
            return Result.Success(project);
        }
        catch (Exception)
        {
            return Result<Project>.Fail("Failed to create project!");
        }
    }
}
