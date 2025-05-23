using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Projects.GetAllProjects;
using TrelloManagementSystem.Features.Tasks.GetTaskById;
using TrelloManagementSystem.Features.Tasks.GetTaskById.Query;

namespace TrelloManagementSystem.Features.Tasks.GetAllTasks
{
    public class GetAllTaskEndpoint : BaseEndpoint<Object, List<GetTaskResponseViewModel>>
    {
        private readonly BaseEndpointParameters<GetTaskResponseViewModel> _parameters;

        public GetAllTaskEndpoint(BaseEndpointParameters<GetTaskResponseViewModel> parameters) : base(parameters.Mediator,parameters.Mapper)
        {
            _parameters = parameters;
        }


        [HttpGet]
        public async Task<EndpointResponse<List<GetTaskResponseViewModel>>> GetAllTask()
            {
            var result = await Mediator.Send(new GetAllTaskQuery());
            if (!result.IsSuccess)
                return EndpointResponse<List<GetTaskResponseViewModel>>.Failure(ErrorCode.TaskNotFound);

            var mapped = Mapper.Map<List<GetTaskResponseViewModel>>(result.Data);

            return EndpointResponse<List<GetTaskResponseViewModel>>.Success(mapped);

        }
    }
}
