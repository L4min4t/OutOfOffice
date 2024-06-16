using AutoMapper;
using Backend.Lists.Employees;
using Backend.Lists.Projects;

namespace Backend.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<Employee, EmployeeDto>()
            .ForMember
            (
                dest => dest.ProjectsId,
                opt => opt.MapFrom
                    (src => src.EmployeeProjects.Select(ep => ep.ProjectId))
            );
    }
}
