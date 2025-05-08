using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TrelloManagementSystem.Common.Response
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseEndpoint<TRequest , TResponse> : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IMediator Mediator => _mediator;
        public IMapper Mapper => _mapper;
        public BaseEndpoint(IMediator mediator , IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }
        //protected Task<EndpointResponse<TResponse>> ValidateAsync(TRequest request)
        //{
        //    var validationResult =  _validator.Validate(request);
        //    if (!validationResult.IsValid)
        //    {
        //        var validateError = string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage));
        //        return Task.FromResult(EndpointResponse<TResponse>.Failure(ErrorCode.InvalidInput));
        //    }
        //    return Task.FromResult(EndpointResponse<TResponse>.Success(default!));
        //}

    }
}
