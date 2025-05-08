using AutoMapper;
using MediatR;

namespace TrelloManagementSystem.Common.RequestStructure
{
    public class BaseRequestParameters
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IMapper Mapper => _mapper;

        public BaseRequestParameters(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
