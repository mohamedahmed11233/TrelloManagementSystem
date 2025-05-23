using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.GetTaskById.Query
{
    public class GetAllTaskQueryHandler : BaseRequestHandler<GetAllTaskQuery, RequestResult<List<GetTaskDto>>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<ProjectTask> _genericRepository;

        public GetAllTaskQueryHandler(BaseRequestParameters parameters, GenericRepository<ProjectTask> genericRepository) : base(parameters)
        {
            _parameters = parameters;
            _genericRepository = genericRepository;
        }

        public override async Task<RequestResult<List<GetTaskDto>>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _genericRepository.Get(
                x => !x.IsDeleted,       // شرط إن العنصر مش محذوف
                x => x.Project,          // تضمين مشروع المهمة
                x => x.User              // تضمين المستخدم المسؤول
            );

            var mappedTasks = _parameters.Mapper.Map<List<GetTaskDto>>(tasks);

            return RequestResult<List<GetTaskDto>>.Success(mappedTasks);
        }

    }
}
