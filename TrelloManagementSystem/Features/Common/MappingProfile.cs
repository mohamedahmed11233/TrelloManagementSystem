using AutoMapper;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Features.Projects.GetAllProjects;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProjectDto, Project>().ReverseMap();
            CreateMap<AddProjectRequestViewModel, AddProjectDto>().ReverseMap();
            CreateMap<AddProjectDto, AddProjectResponseViewModel>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectDto, ProjectsResponseViewModel>();
            CreateMap<ProjectsRequestViewModel, ProjectDto>();
            CreateMap<ProjectTask, ProjectTaskDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ProjectDto, ProjectsResponseViewModel>();
            CreateMap<ProjectDto, ProjectsResponseViewModel>();
            CreateMap<RequestResult<IEnumerable<ProjectDto>>, IEnumerable<ProjectsResponseViewModel>>();
            CreateMap<Project, ProjectsResponseViewModel>();
          


        }
    }
}
