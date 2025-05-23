using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Tasks.GetTaskById;

namespace TrelloManagementSystem.Features.Tasks.EditeTask.Commend
{
    public class UpdateTaskEndpoint : BaseEndpoint<UpdaterequetTaskViewModel, GetTaskResponseViewModel>
    {
        private readonly BaseEndpointParameters<UpdaterequetTaskViewModel> _parameters;

        public UpdateTaskEndpoint(BaseEndpointParameters<UpdaterequetTaskViewModel> parameters) : base(parameters.Mediator, parameters.Mapper)
        {
            _parameters = parameters;
        }


        [HttpPut]
        public async Task<EndpointResponse<GetTaskResponseViewModel>> UpdateTaskAsync(UpdaterequetTaskViewModel model)
        {
            var updateTaskDto = _parameters.Mapper.Map<UpdateTaskDto>(model);
            var result = await _parameters.Mediator.Send(new UpdateTaskCommend(updateTaskDto));

            if (!result.IsSuccess || result.Data == null)
                return EndpointResponse<GetTaskResponseViewModel>.Failure(ErrorCode.FailedUpdateTask);

            var responseViewModel = _parameters.Mapper.Map<GetTaskResponseViewModel>(result.Data);
            return EndpointResponse<GetTaskResponseViewModel>.Success(responseViewModel);
        }



    }
}
