using AutoMapper;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Projects.UpdateProject;
using TrelloManagementSystem.Features.Tasks.AddTask;
using TrelloManagementSystem.Features.Tasks.EditeTask;
using TrelloManagementSystem.Features.Tasks.GetTaskById;
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
            CreateMap<RequestResult<ProjectRequestViewModel>, Project>();
            CreateMap<RequestResult<bool>, bool>();

            #region Task Mapping

            CreateMap<AddTaskRequestViewModel, AddTaskDto>().ReverseMap();
            CreateMap<AddTaskDto, ProjectTask>().ReverseMap();
            CreateMap<AddTaskDto, AddTaskResponseViewModel>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskDto>().ReverseMap();

            CreateMap<GetTaskResponseViewModel, GetTaskDto>().ReverseMap();
            
            CreateMap<UpdaterequetTaskViewModel, UpdateTaskDto>().ReverseMap();
            
            CreateMap<UpdaterequetTaskViewModel, UpdateTaskDto>().ReverseMap();


            CreateMap<ProjectTask, GetTaskDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.Project.Title));




            #endregion

        }
    }
}
