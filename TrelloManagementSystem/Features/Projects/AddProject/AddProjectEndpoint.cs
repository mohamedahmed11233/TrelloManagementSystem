using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Projects.AddProject.Command;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.AddProject
{
    public class AddProjectEndpoint : BaseEndpoint<AddProjectRequestViewModel, AddProjectResponseViewModel>
    {
        private readonly BaseEndpointParameters<AddProjectRequestViewModel> _parameters;
        public AddProjectEndpoint(BaseEndpointParameters<AddProjectRequestViewModel> parameters): base(parameters.Mediator, parameters.Mapper)
        {
            _parameters = parameters;
        }
        [HttpPost("AddProject")]
        public async Task<EndpointResponse<AddProjectResponseViewModel>> AddProject(AddProjectRequestViewModel model)
        {
            var projectDto = _parameters.Mapper.Map<AddProjectDto>(model);
            var project = await _parameters.Mediator.Send(new AddProjectCommand(projectDto));
            var response = new AddProjectResponseViewModel
            {    Id = project.Data.Id,
                Description = project.Data.Description,
                Title = project.Data.Title
            };
            return EndpointResponse<AddProjectResponseViewModel>.Success(response);
        }
    }
}
