using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Tasks.GetTaskById;
using TrelloManagementSystem.Features.Tasks.GetTaskById.Query;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.EditTask.Commend
{
    public class UpdateTaskCommendHandler : BaseRequestHandler<UpdateTaskCommend, RequestResult<GetTaskDto>>
    {
        private readonly GenericRepository<ProjectTask> _repository;
        private readonly BaseRequestParameters _parameters;

        public UpdateTaskCommendHandler(BaseRequestParameters parameters, GenericRepository<ProjectTask> repository)
            : base(parameters)
        {
            _repository = repository;
            _parameters = parameters;
        }

        public override async Task<RequestResult<GetTaskDto>> Handle(UpdateTaskCommend request, CancellationToken cancellationToken)
        {
            var existingTask = await _repository.GetByIdAsync(request.UpdateTaskDto.Id);
            if (existingTask == null)
                return RequestResult<GetTaskDto>.Failure(ErrorCode.TaskNotFound);

            existingTask.Title = request.UpdateTaskDto.Title;
            existingTask.Description = request.UpdateTaskDto.Description;
            existingTask.ProjectId = request.UpdateTaskDto.ProjectId;
            existingTask.UserId = request.UpdateTaskDto.UserId;

            var modifiedProperties = new string[]
            {
                nameof(ProjectTask.Title),
                nameof(ProjectTask.Description),
                nameof(ProjectTask.ProjectId),
                nameof(ProjectTask.UserId)
            };

            await _repository.UpdateInclude(existingTask, modifiedProperties);

            var updatedTaskResult = await _parameters.Mediator.Send(new GeyTaskByIdQuery(existingTask.Id));

            if (!updatedTaskResult.IsSuccess || updatedTaskResult.Data == null)
                return RequestResult<GetTaskDto>.Failure(ErrorCode.FailedUpdateTask);

            return RequestResult<GetTaskDto>.Success(updatedTaskResult.Data);
        }
    }
}
