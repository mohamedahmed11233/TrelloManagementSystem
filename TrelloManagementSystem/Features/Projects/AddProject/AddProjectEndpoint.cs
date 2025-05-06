using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.AddProject.Command;

namespace TrelloManagementSystem.Features.Projects.AddProject
{
    public class AddProjectEndpoint : BaseEndpoint<AddProjectCommand, RequestResult<AddProjectDto>>
    {
        private readonly BaseEndpointParameters<AddProjectCommand> _parameters;
        private readonly IValidator<AddProjectCommand> _validator;
        public AddProjectEndpoint(BaseEndpointParameters<AddProjectCommand> parameters): base(parameters.Validator)
        {
            _parameters = parameters;
            _validator = parameters.Validator;
        }
        [HttpPost] 

    }
}
