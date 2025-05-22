using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.CommonFeatures.UsersMangment.GetUserById.GetUserByIdQuery;
using TrelloManagementSystem.Features.Projects.AddProject;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Tasks.AddTask.Commend
{
    public class AddTaskCommendHandler : BaseRequestHandler<AddTaskCommand, RequestResult<AddTaskDto>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<ProjectTask> _genericRepository;

        public AddTaskCommendHandler(BaseRequestParameters parameters , GenericRepository<ProjectTask> genericRepository) : base(parameters)
        {
            _parameters = parameters;
            _genericRepository = genericRepository;
        }
        public override async Task<RequestResult<AddTaskDto>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
           
            var userResult = await _parameters.Mediator.Send(new GetUserByIdQuery(request.AddTaskDto.UserId));

            if (!userResult.IsSuccess || userResult.Data == null)
            {
                return RequestResult<AddTaskDto>.Failure(ErrorCode.UserNotFound);
            }

            var existingTask = await _genericRepository.GetBySpecAsync(
                t => t.Title == request.AddTaskDto.Title &&
                     t.UserId == request.AddTaskDto.UserId &&
                     t.ProjectId == request.AddTaskDto.ProjectId
            );

            if (existingTask != null)
            {
                return RequestResult<AddTaskDto>.Failure(ErrorCode.TaskAlreadyExists);
            }

            var task = _parameters.Mapper.Map<ProjectTask>(request.AddTaskDto);
            await _genericRepository.AddAsync(task);
            await _genericRepository.SaveChangesAsync();

            var addedTaskDto = _parameters.Mapper.Map<AddTaskDto>(task);
            return RequestResult<AddTaskDto>.Success(addedTaskDto, "Task added successfully");
        }
    }
}
