using Backend.Lists.Projects;
using Backend.ResultPattern;

namespace Backend.Services.Interfaces;

public interface IProjectService : IBaseService<Project>
{
    Task<Result<Project>> CreateAsync(CreateProjectDto dto);
}
