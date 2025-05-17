using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
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
            {
                return RequestResult<bool>.Failure(ErrorCode.InvalidInput);
            }
            var project = await _repository.GetByIdAsync(request.Id);
            if (project is null)
            {
                return RequestResult<bool>.Failure(ErrorCode.ProjectNotFound);
            }
            await _repository.DeleteAsync(project);
            return RequestResult<bool>.Success(true);
        }
    }

}
