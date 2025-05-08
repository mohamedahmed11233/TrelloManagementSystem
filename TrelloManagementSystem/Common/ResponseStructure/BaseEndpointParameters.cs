using AutoMapper;
using FluentValidation;
using MediatR;
using TrelloManagementSystem.Features.Common;

namespace TrelloManagementSystem.Common.Response
{
    public class BaseEndpointParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IMapper Mapper => _mapper;

        public BaseEndpointParameters(IMediator mediator  , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
