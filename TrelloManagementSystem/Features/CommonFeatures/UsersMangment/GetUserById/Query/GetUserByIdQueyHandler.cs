using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Tasks.AddTask;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.CommonFeatures.UsersMangment.GetUserById.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : BaseRequestHandler<GetUserByIdQuery, RequestResult<UserDto>>
    {
        private readonly BaseRequestParameters _parameters;
        private readonly GenericRepository<User> _genericRepository;

        public GetUserByIdQueryHandler(BaseRequestParameters parameters, GenericRepository<User> genericRepository) : base(parameters)
        {
            _parameters = parameters;
            _genericRepository = genericRepository;
        }
        public override async Task<RequestResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return RequestResult<UserDto>.Failure(ErrorCode.UserNotFound);

            var userDto = _parameters.Mapper.Map<UserDto>(user);

            return RequestResult<UserDto>.Success(userDto);


        }
    }
}
