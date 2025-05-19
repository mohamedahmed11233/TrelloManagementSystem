using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.DeleteProject.DeletionOrchestrator;

namespace TrelloManagementSystem.Features.Projects.DeleteProject
{
    public class DeleteProjectByIdEndpoint : BaseEndpoint<RequestResult<int>, RequestResult<bool>>
    {
        public DeleteProjectByIdEndpoint(BaseEndpointParameters<int> parameters) : base(parameters.Mediator, parameters.Mapper) { }

        [HttpDelete("{Id}")]
        public async Task<EndpointResponse<bool>> DeleteProjectById(int Id)
        {
            var project = await Mediator.Send(new DeleteProjectOrchestrator(Id));
            var map = Mapper.Map<bool>(project);            
                return EndpointResponse<bool>.Success(map);
        }
    }
}
