using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;

namespace TrelloManagementSystem.Features.Projects.GetAllProjects
{
    public class GetAllProjectsEndpoint : BaseEndpoint<IEnumerable<ProjectsRequestViewModel> , IEnumerable<ProjectsResponseViewModel>>
    {

        public GetAllProjectsEndpoint(BaseEndpointParameters<IEnumerable<ProjectsRequestViewModel>> parameters) : base(parameters.Mediator , parameters.Mapper)
        {
        }
        [HttpGet("GetAllProjects")]
        public async Task<EndpointResponse<IEnumerable<ProjectsResponseViewModel>>> GetAllProjects(string? Title)
        {
            var projects = await Mediator.Send(new GetAllProjectsQuery(Title));
            var response = Mapper.Map<IEnumerable<ProjectsResponseViewModel>>(projects);

            return EndpointResponse<IEnumerable<ProjectsResponseViewModel>>.Success(response);

        }
    }
}
