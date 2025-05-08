using AutoMapper;
using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.AddProject.Command
{
    public sealed record AddProjectCommand(AddProjectDto Dto):IRequest<RequestResult<AddProjectDto>>;
    public class AddProjectCommandHandler : BaseRequestHandler<AddProjectCommand, RequestResult<AddProjectDto>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<Project> _projectRepo;

        public AddProjectCommandHandler(BaseRequestParameters parameters , GenericRepository<Project> projectRepo ) : base(parameters)
        {
            this._parameters = parameters;
            this._projectRepo = projectRepo;
        }

        public override async Task<RequestResult<AddProjectDto>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            if (request.Dto is null)
                return RequestResult<AddProjectDto>.Failure(ErrorCode.FailedCreateProject);
            var project = _parameters.Mapper.Map<Project>(request.Dto);
            try
            {
                await _projectRepo.AddAsync(project);
                await _projectRepo.SaveChangesAsync();
            }
            catch (Exception)
            {

                RequestResult<AddProjectDto>.Failure(ErrorCode.FailedCreateProject);
            }
            var projectDto = _parameters.Mapper.Map<AddProjectDto>(project);
            return RequestResult<AddProjectDto>.Success(projectDto);
        }
    }

}
