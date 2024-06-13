using Backend.Lists.Projects;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class ProjectService : BaseService<Project>, IProjectService
{
    public ProjectService(IProjectRepository repository) : base(repository)
    {
    }
}