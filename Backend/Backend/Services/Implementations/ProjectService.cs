using Backend.Lists.Projects;
using Backend.Repositories.Interfaces;
using Backend.Servises.Interfaces;

namespace Backend.Servises.Implementations;

public class ProjectService : BaseService<Project>, IProjectService
{
    public ProjectService(IBaseRepository<Project> repository) : base(repository)
    {
    }
}