
using TrelloManagementSystem.Common.Helper.ExtensionMethod;

namespace TrelloManagementSystem.Common.Response
{
    public record RequestResult<T>(T Data, bool IsSuccess, string Message, ErrorCode ErrorCode)
    {
        public static RequestResult<T> Success(T data, string message = "")
        {
            return new RequestResult<T>(data, true, message, ErrorCode.None);
        }

        public static RequestResult<T> Failure(ErrorCode errorCode)
        {
            return new RequestResult<T>(default, false, errorCode.GetDescription(), errorCode);
        }
    }
}