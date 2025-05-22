using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Projects.AddProject;

namespace TrelloManagementSystem.Features.Tasks.AddTask.Commend
{
    public record AddTaskCommand(AddTaskDto AddTaskDto) : IRequest<RequestResult<AddTaskDto>>;
   
}
