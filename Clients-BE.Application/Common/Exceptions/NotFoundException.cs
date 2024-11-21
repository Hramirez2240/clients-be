using Response = Clients_BE.Application.Common.BaseResponse;

namespace Clients_BE.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public Response Response { get; }

        public NotFoundException(string entityName, Guid id)
          : base($"{entityName} with id {id} not found")
        {
            Response = Response.NotFound(Message);
        }
    }
}
