using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.UpdateExpiredTasks
{
    public class UpdateExpiredTasksHandler:BaseRequestHandler<UpdateExpiredTasksCommand,RequestResult<string>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<ProjectTask> _genericRepository;

        public UpdateExpiredTasksHandler(BaseRequestParameters parameters, GenericRepository<ProjectTask> genericRepository) :base(parameters) 
        {
            _parameters = parameters;
            _genericRepository = genericRepository;

        }
        public override async Task<RequestResult<string>> Handle(UpdateExpiredTasksCommand request, CancellationToken cancellationToken)
        {
            var expiredTasks = await _genericRepository.Get(t =>
                 t.Deadline < DateTime.Now &&
                 t.TaskStatus != TasksStatus.Expired
             );


            foreach (var task in expiredTasks)
            {
                task.TaskStatus = TasksStatus.Expired;

                 await _genericRepository.UpdateInclude(task, nameof(ProjectTask.TaskStatus));
            }

            return RequestResult<string>.Success("Expired tasks updated successfully");
        }
    }
}
