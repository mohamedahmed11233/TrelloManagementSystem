using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Projects.GetProjectById.Query;

namespace TrelloManagementSystem.Features.Projects.GetProjectById
{
    public class GetProjectByIdEndpoint:BaseEndpoint<ProjectRequestViewModel , ProjectResponseViewModel>
    {
        public GetProjectByIdEndpoint(BaseEndpointParameters<ProjectRequestViewModel> parameters) :base(parameters.Mediator, parameters.Mapper){ }
        [HttpGet("/{Id}")]
        public async Task<EndpointResponse<ProjectResponseViewModel>> GetProjectById(int Id)
        {
            var project =await Mediator.Send(new GetProjectByIDQuery(Id));
            var mappedproject = Mapper.Map<RequestResult<ProjectRequestViewModel>, ProjectResponseViewModel>(project);
            return EndpointResponse<ProjectResponseViewModel>.Success(mappedproject);

        }
    }
}
