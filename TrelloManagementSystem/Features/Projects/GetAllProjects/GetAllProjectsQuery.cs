using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.GetAllProjects
{
    public sealed record GetAllProjectsQuery(string? Title) :IRequest<RequestResult<IEnumerable<ProjectRequestViewModel>>>;
    public class GetAllProjectsQueryHandler : BaseRequestHandler<GetAllProjectsQuery, RequestResult<IEnumerable<ProjectRequestViewModel>>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<Project> _repository;

        public GetAllProjectsQueryHandler(BaseRequestParameters parameters , GenericRepository<Project> repository) :base(parameters)
        {
            _parameters = parameters;
            _repository = repository;
        }

        public override async Task<RequestResult<IEnumerable<ProjectRequestViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                var projects = await _repository.Get(x => x.Title == request.Title);
                var mappedProjects = _parameters.Mapper.Map<IEnumerable<ProjectRequestViewModel>>(projects);
                return RequestResult<IEnumerable<ProjectRequestViewModel>>.Success(mappedProjects);
            }
            else
            {
                var projects = await _repository.Get(null! , x => x.Users , x=>x.Tasks);
                var mappedProjects = _parameters.Mapper.Map<IEnumerable<ProjectRequestViewModel>>(projects);
                return RequestResult<IEnumerable<ProjectRequestViewModel>>.Success(mappedProjects);
            }

        }
    }
}
