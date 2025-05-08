using AutoMapper;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProjectDto, Project>().ReverseMap();
            CreateMap<AddProjectRequestViewModel, AddProjectDto>().ReverseMap();
            CreateMap<AddProjectDto, AddProjectResponseViewModel>().ReverseMap();
        }
    }
}
