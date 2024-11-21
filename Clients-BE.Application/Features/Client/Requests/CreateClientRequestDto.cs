using Clients_BE.Application.Features.Address.Requests;

namespace Clients_BE.Application.Features.Client.Requests
{
    public class CreateClientRequestDto
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<CreateAddressRequestDto> Addresses { get; set; } = [];
    }
}
