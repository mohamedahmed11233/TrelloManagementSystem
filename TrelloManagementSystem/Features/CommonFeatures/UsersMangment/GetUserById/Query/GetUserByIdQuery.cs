using MediatR;
using TrelloManagementSystem.Common.Request;
using TrelloManagementSystem.Features.Common;

namespace TrelloManagementSystem.Features.CommonFeatures.UsersMangment.GetUserById.GetUserByIdQuery
{
    public record GetUserByIdQuery(int UserId): IRequest<RequestResult<UserDto>>;
    
}
