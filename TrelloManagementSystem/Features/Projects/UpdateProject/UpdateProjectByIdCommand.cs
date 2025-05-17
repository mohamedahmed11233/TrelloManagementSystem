using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.UpdateProject
{
    public sealed record UpdateProjectByIdCommand(int Id):IRequest<RequestResult<UpdateProjectRequestViewModel>>;
    public class UpdateProjectByIdCommandHandler : IRequestHandler<UpdateProjectByIdCommand, RequestResult<UpdateProjectRequestViewModel>>
    {
        private readonly GenericRepository<Project> _repository;
        private readonly BaseRequestParameters _parameters;
        public UpdateProjectByIdCommandHandler(BaseRequestParameters parameters, GenericRepository<Models.Project> repository)
        {
            _parameters = parameters;
            _repository = repository;
        }
        public async Task<RequestResult<UpdateProjectRequestViewModel>> Handle(UpdateProjectByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                return RequestResult<UpdateProjectRequestViewModel>.Failure(ErrorCode.InvalidInput);
            }
            var project = await _repository.GetByIdAsync(request.Id);
            if (project is null)
            {
                return RequestResult<UpdateProjectRequestViewModel>.Failure(ErrorCode.ProjectNotFound);
            }
            var mappedProject = _parameters.Mapper.Map<Project , UpdateProjectRequestViewModel>(project);
            return RequestResult<UpdateProjectRequestViewModel>.Success(mappedProject);
        }
    }

}
