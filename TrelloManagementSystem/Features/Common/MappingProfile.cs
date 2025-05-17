using AutoMapper;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Projects.UpdateProject;
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
            CreateMap<ProjectTask, ProjectTaskDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Project, ProjectRequestViewModel>().ReverseMap();
            CreateMap<ProjectRequestViewModel, ProjectResponseViewModel>();
            CreateMap<Project, ProjectRequestViewModel>().ReverseMap();
            CreateMap<RequestResult<ProjectRequestViewModel>, ProjectResponseViewModel>().ReverseMap();
            CreateMap<RequestResult<UpdateProjectRequestViewModel>, UpdateProjectResponseViewModel>();
            CreateMap<Project, UpdateProjectRequestViewModel>();
            CreateMap<RequestResult<bool>, RequestResult<int>>();
        }
    }
}
