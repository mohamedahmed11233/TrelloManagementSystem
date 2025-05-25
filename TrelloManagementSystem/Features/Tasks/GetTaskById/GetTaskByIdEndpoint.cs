using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.Common;
using TrelloManagementSystem.Features.Tasks.GetTaskById.Query;

namespace TrelloManagementSystem.Features.Tasks.GetTaskById
{
    public class GetTaskByIdEndpoint : BaseEndpoint<int, GetTaskResponseViewModel>
    {
        private readonly BaseEndpointParameters<GetTaskResponseViewModel> _parameters;

        public GetTaskByIdEndpoint(BaseEndpointParameters<GetTaskResponseViewModel> parameters) : base(parameters.Mediator,parameters.Mapper)
        {
            _parameters = parameters;
        }


        [HttpGet("{id}")]
        public async Task<EndpointResponse<GetTaskResponseViewModel>> GetTaskById(int id)
        {
            var result = await Mediator.Send(new GeyTaskByIdQuery(id));

            if (!result.IsSuccess)
            {
                // You can customize failure response here if needed
                return EndpointResponse<GetTaskResponseViewModel>.Failure(ErrorCode.TaskNotFound);
            }

            var mapped = Mapper.Map<GetTaskResponseViewModel>(result.Data);
            return EndpointResponse<GetTaskResponseViewModel>.Success(mapped);
        }
    }
}
