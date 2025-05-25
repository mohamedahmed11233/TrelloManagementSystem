using MediatR;
using TrelloManagementSystem.Common.Request;

namespace TrelloManagementSystem.Features.Tasks.UpdateExpiredTasks
{
    public record UpdateExpiredTasksCommand:IRequest<RequestResult<string>>;
}
