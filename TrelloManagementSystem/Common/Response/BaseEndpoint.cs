using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace TrelloManagementSystem.Common.Response
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseEndpoint<TRequest , TResponse> : ControllerBase
    {
        private readonly IValidator<TRequest> _validator;

        public BaseEndpoint(IValidator<TRequest> validator)
        {
            this._validator = validator;
        }
        public Task<EndpointResponse<TResponse>> ValidateAsync(TRequest request)
        {
            var validationResult =  _validator.Validate(request);
            if (!validationResult.IsValid)
            {
               return Task.FromResult(EndpointResponse<TResponse>.Failure(ErrorCode.InvalidInput ));
            }
            return Task.FromResult(EndpointResponse<TResponse>.Success(default!));
        }

    }
}
