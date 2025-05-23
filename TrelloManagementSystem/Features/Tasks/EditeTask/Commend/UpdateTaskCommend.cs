using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Tasks.GetTaskById;

namespace TrelloManagementSystem.Features.Tasks.EditeTask.Commend
{
    public record UpdateTaskCommend(UpdateTaskDto UpdateTaskDto ): IRequest<RequestResult<GetTaskDto>>;
   
}
