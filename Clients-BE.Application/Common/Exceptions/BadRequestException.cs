using Response = Clients_BE.Application.Common.BaseResponse;

namespace Clients_BE.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public Response Response { get; }

        public BadRequestException(string message)
            : base(message)
        {
            Response = Response.BadRequest(message);
        }
    }
}
