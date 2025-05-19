using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.Response;

namespace TrelloManagementSystem.Features.Projects.UpdateProject
{
    public class UpdateProjectEndpoint : BaseEndpoint<UpdateProjectRequestViewModel,UpdateProjectResponseViewModel>
    {
        public UpdateProjectEndpoint(BaseEndpointParameters<UpdateProjectResponseViewModel> parameters):base(parameters.Mediator , parameters.Mapper) { }

        [HttpPut("{Id}")]
        public async Task<EndpointResponse<UpdateProjectResponseViewModel>> UpdateProject(UpdateProjectRequestViewModel request)
        {
            var project = await Mediator.Send(new UpdateProjectByIdCommand(request.Id));
            var mappedProject = Mapper.Map<RequestResult<UpdateProjectRequestViewModel>, UpdateProjectResponseViewModel>(project);
            return EndpointResponse<UpdateProjectResponseViewModel>.Success(mappedProject);
        }
    }
}
