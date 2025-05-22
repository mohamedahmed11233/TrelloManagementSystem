using Microsoft.AspNetCore.Mvc;
using TrelloManagementSystem.Common.Enums;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Features.Projects.AddProject.Command;
using TrelloManagementSystem.Features.Tasks.AddTask.Commend;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.AddTask
{
    public class AddTaskEndpoint : BaseEndpoint<AddTaskRequestViewModel, AddTaskResponseViewModel>
    {
        private readonly BaseEndpointParameters<AddTaskResponseViewModel> _endpointParameters;

        public AddTaskEndpoint(BaseEndpointParameters<AddTaskResponseViewModel> endpointParameters): base(endpointParameters.Mediator,endpointParameters.Mapper)
        {
            _endpointParameters = endpointParameters;
        }

        [HttpPost("AddTask")]
        public async Task<EndpointResponse<AddTaskResponseViewModel>> AddTask(AddTaskRequestViewModel model)
        {
            var taskDto = _endpointParameters.Mapper.Map<AddTaskDto>(model);

            var task = await _endpointParameters.Mediator.Send(new AddTaskCommand(taskDto));

            // 🟢 خُد الـ Data فقط من الـ result
            var result = _endpointParameters.Mapper.Map<AddTaskResponseViewModel>(task.Data);

            if (task.IsSuccess)
                return EndpointResponse<AddTaskResponseViewModel>.Success(result, "Task Added Successfully");

            return EndpointResponse<AddTaskResponseViewModel>.Failure(ErrorCode.FailedCreateTask);
        }

    }
}
