using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.GetTaskById.Query
{
    public class GeyTaskByIdQueryHandler : BaseRequestHandler<GeyTaskByIdQuery, RequestResult<GetTaskDto>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<ProjectTask> _genericRepository;

        public GeyTaskByIdQueryHandler(BaseRequestParameters parameters, GenericRepository<ProjectTask> genericRepository) : base(parameters)
        {
            _parameters = parameters;
            _genericRepository = genericRepository;
        }

        public override async Task<RequestResult<GetTaskDto>> Handle(GeyTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _genericRepository.Get(
                x => x.Id == request.taskId,
                x => x.Project,
                x => x.User
            );

            var task = result.FirstOrDefault();

            if (task == null)
                return RequestResult<GetTaskDto>.Failure(ErrorCode.TaskNotFound);

            var dto = _parameters.Mapper.Map<GetTaskDto>(task);
            dto.ProjectTitle = task.Project?.Title;
            dto.UserName = task.User?.FirstName;

            return RequestResult<GetTaskDto>.Success(dto);
        }
    }
}
