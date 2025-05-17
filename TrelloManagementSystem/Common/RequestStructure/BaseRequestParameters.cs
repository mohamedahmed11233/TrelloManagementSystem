using AutoMapper;
using MediatR;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Common.RequestStructure
{
    public class BaseRequestParameters
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Project> _repository;

        public IMediator Mediator => _mediator;
        public IMapper Mapper => _mapper;
        public GenericRepository<Project> Repository => _repository;

        public BaseRequestParameters(IMediator mediator , IMapper mapper , GenericRepository<Project> repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }
    }
}
