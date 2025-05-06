using AutoMapper;
using MediatR;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Projects.AddProject.Command
{
    public sealed record AddProjectCommand :IRequest<RequestResult<AddProjectDto>>;

    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, RequestResult<AddProjectDto>>
    {
        private readonly GenericRepository<Project> _projectRepo;
        private readonly IMapper _mapper;

        public AddProjectCommandHandler(GenericRepository<Project> projectRepo , IMapper mapper )
        {
            this._projectRepo = projectRepo;
            this._mapper = mapper;
        }
        public Task<RequestResult<AddProjectDto>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(RequestResult<AddProjectDto>.Failure(ErrorCode.InvalidInput));
        }
    }

}
