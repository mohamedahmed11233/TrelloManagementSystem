using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Projects.GetProjectById.Query;

namespace TrelloManagementSystem.Features.Projects.DeleteProject.DeletionOrchestrator
{
    public sealed record DeleteProjectOrchestrator(int Id) :IRequest<RequestResult<bool>>;
    public class DeleteProjectOrchestratorHandler : IRequestHandler<DeleteProjectOrchestrator, RequestResult<bool>>
    {
        private readonly BaseRequestParameters _parameters;

        public DeleteProjectOrchestratorHandler(BaseRequestParameters parameters)
        {
            _parameters = parameters;
        }

        public  Task<RequestResult<bool>> Handle(DeleteProjectOrchestrator request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            return Task.FromResult(RequestResult<bool>.Failure(ErrorCode.InvalidInput));
            
                 var project = _parameters.Mediator.Send(new GetProjectByIDQuery(request.Id));
            if (project is null)
            
                return Task.FromResult(RequestResult<bool>.Failure(ErrorCode.ProjectNotFound));
            
            var deleteProject = _parameters.Mediator.Send(new DeleteProjectByIdCommand(request.Id));
            return Task.FromResult(RequestResult<bool>.Success(true));
        }
    }

}
