using Azure.Core;
using MediatR;
using TrelloManagementSystem.Common.Request;

namespace TrelloManagementSystem.Features.Tasks.GetTaskById.Query
{
    public record GetAllTaskQuery:IRequest<RequestResult<List<GetTaskDto>>>;

}
