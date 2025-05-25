using MediatR;
using TrelloManagementSystem.Features.Tasks.UpdateExpiredTasks;

namespace TrelloManagementSystem.Features.CommonFeatures.BackgroundJobs.TasksJop
{
    public class UpdateExpiredTasksJob
    {
        private readonly IMediator _mediator;

        public UpdateExpiredTasksJob(IMediator mediator)
        {
            _mediator = mediator;
        }
            
        public async Task Run()
        {
            await _mediator.Send(new UpdateExpiredTasksCommand());
        }
    }

}
