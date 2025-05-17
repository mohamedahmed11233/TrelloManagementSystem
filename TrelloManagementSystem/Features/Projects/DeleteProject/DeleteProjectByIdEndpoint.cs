using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.DeleteProject.DeleteProjectEvent;

namespace TrelloManagementSystem.Features.Projects.DeleteProject
{
    public class DeleteProjectByIdEndpoint : BaseEndpoint<RequestResult<int>, RequestResult<bool>>
    {
        public DeleteProjectByIdEndpoint(BaseEndpointParameters<int> parameters) : base(parameters.Mediator, parameters.Mapper) { }

        [HttpDelete("{Id}")]
        public async Task<EndpointResponse<bool>> DeleteProjectById(int Id)
        {
            var project = await Mediator.Send(new ProjectDeletionEvent(Id));

            // Explicitly cast 'project' to the expected type to resolve the error
            var mappedProject = Mapper.Map<RequestResult<bool>>((RequestResult<int>)project);

            return EndpointResponse<bool>.Success(mappedProject.Data);
        }
    }
}
