using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Projects.DeleteProject.DeleteProjectEvent;
using TrelloManagementSystem.Features.Projects.GetProjectById.Query;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.DeleteProject
{
    public sealed record DeleteProjectByIdCommand (int Id) : IRequest<RequestResult<bool>>;
    public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, RequestResult<bool>>
    {
        private readonly GenericRepository<Project> _repository;
        private readonly BaseRequestParameters _parameters;
        public DeleteProjectByIdCommandHandler(BaseRequestParameters parameters, GenericRepository<Project> repository)
        {
            _parameters = parameters;
            _repository = repository;
        }
        public async Task<RequestResult<bool>> Handle(DeleteProjectByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
             return RequestResult<bool>.Failure(ErrorCode.InvalidInput);
            

            var project = await _parameters.Mediator.Send(new GetProjectByIDQuery(request.Id));
            if (project is null)
                return RequestResult<bool>.Failure(ErrorCode.ProjectNotFound);
            
            await _parameters.Mediator.Publish(new ProjectDeletionEvent(request.Id));
            var mappedProject = _parameters.Mapper.Map<RequestResult<ProjectRequestViewModel>, Project>(project);
            await _repository.DeleteAsync(mappedProject);
            await _repository.SaveChangesAsync();
            return RequestResult<bool>.Success(true);
        }
    }

}
