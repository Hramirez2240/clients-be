using Clients_BE.Application.Features.Address.Responses;

namespace Clients_BE.Application.Features.Client.Responses
{
    public class ClientResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<AddressResponseDto> Addresses { get; set; } = [];
    }
}
