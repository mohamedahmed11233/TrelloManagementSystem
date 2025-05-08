using MediatR;
using TrelloManagementSystem.Common.RequestStructure;

namespace TrelloManagementSystem.Common.Request
{
    public abstract class BaseRequestHandler<TRequest , TResponse> : IRequestHandler<TRequest , TResponse> where TRequest : IRequest<TResponse>
    {
        protected IMediator _mediator;
        public BaseRequestHandler(BaseRequestParameters parameters) 
        {
            _mediator = parameters.Mediator;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
                
    }
}
