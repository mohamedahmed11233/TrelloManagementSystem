using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.Common;

namespace TrelloManagementSystem.Features.Projects.GetAllProjects
{
    public class GetAllProjectsEndpoint : BaseEndpoint<IEnumerable<ProjectRequestViewModel> , IEnumerable<ProjectResponseViewModel>>
    {
        public GetAllProjectsEndpoint(BaseEndpointParameters<IEnumerable<ProjectRequestViewModel>> parameters) : base(parameters.Mediator , parameters.Mapper)
        {
        }
        [HttpGet("GetAllProjects")]
        public async Task<EndpointResponse<IEnumerable<ProjectResponseViewModel>>> GetAllProjects(string? Title)
        {
            var projects = await Mediator.Send(new GetAllProjectsQuery(Title));
            if (projects.IsSuccess)
            {
                var mappedProjects = Mapper.Map<IEnumerable<ProjectResponseViewModel>>(projects.Data);
                return EndpointResponse<IEnumerable<ProjectResponseViewModel>>.Success(mappedProjects);
            }
            
                return EndpointResponse<IEnumerable<ProjectResponseViewModel>>.Failure(ErrorCode.DoesNotExist);
            

        }
    }
}
