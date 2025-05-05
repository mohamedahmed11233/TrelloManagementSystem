using MediatR;
using TrelloManagementSystem.Common.Response;

namespace TrelloManagementSystem.Features.Projects.AddProject.Command
{
    public sealed record AddProjectCommand :IRequest<RequestResult<AddProjectDto>>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, RequestResult<AddProjectDto>>
    {
        public Task<RequestResult<AddProjectDto>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            // Handle the command logic here
            var result = new AddProjectDto
            {
                Id = 1,
                Title = "New Project",
                Description = "This is a new project"
            };
            return Task.FromResult(RequestResult<AddProjectDto>.Success(result));
        }
    }

}
