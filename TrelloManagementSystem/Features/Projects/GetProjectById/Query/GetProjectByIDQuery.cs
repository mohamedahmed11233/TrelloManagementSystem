using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.GetProjectById.Query
{
   public sealed record GetProjectByIDQuery(int Id) : IRequest<RequestResult<ProjectRequestViewModel>>;
    public class GetProjectByIDQueryHandler : BaseRequestHandler<GetProjectByIDQuery, RequestResult<ProjectRequestViewModel>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<Project> _repository;

        public GetProjectByIDQueryHandler(BaseRequestParameters parameters , GenericRepository<Project> repository) : base(parameters)
        {
            _parameters = parameters;
            _repository = repository;
        }
        public override async Task<RequestResult<ProjectRequestViewModel>> Handle(GetProjectByIDQuery request, CancellationToken cancellationToken)
        {

            if(request.Id <= 0)
            {
                return RequestResult<ProjectRequestViewModel>.Failure(ErrorCode.InvalidInput);
            }
            var project = await _repository.GetByIdAsync(request.Id);
            if (project is null)
            {
                return RequestResult<ProjectRequestViewModel>.Failure(ErrorCode.ProjectNotFound);
            }
            var mappedProject = _parameters.Mapper.Map<ProjectRequestViewModel>(project);
            return RequestResult<ProjectRequestViewModel>.Success(mappedProject);
        }
    }



}
