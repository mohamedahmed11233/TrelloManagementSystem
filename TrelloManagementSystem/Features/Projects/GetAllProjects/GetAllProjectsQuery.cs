using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.GetAllProjects
{
    public sealed record GetAllProjectsQuery(string? Title) :IRequest<RequestResult<IEnumerable<ProjectDto>>>;
    public class GetAllProjectsQueryHandler : BaseRequestHandler<GetAllProjectsQuery, RequestResult<IEnumerable<ProjectDto>>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<Project> _repository;

        public GetAllProjectsQueryHandler(BaseRequestParameters parameters , GenericRepository<Project> repository) :base(parameters)
        {
            this._parameters = parameters;
            this._repository = repository;
        }

        public override async Task<RequestResult<IEnumerable<ProjectDto>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {

            var projects = await _repository.GetAllAsync();
            if(!string.IsNullOrEmpty(request.Title))
                return (RequestResult<IEnumerable<ProjectDto>>)await _repository.Get(p=>!p.IsDeleted , p=>p.Title);
            var projectDtos = _parameters.Mapper.Map<IEnumerable<ProjectDto>>(projects);
            return RequestResult<IEnumerable<ProjectDto>>.Success(projectDtos);

        }
    }
}
