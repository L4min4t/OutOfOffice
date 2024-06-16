using Backend.Contexts;
using Backend.Lists.Projects;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationContext context)
        : base(context)
    {
    }
}
