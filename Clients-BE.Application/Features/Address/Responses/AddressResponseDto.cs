namespace Clients_BE.Application.Features.Address.Responses
{
    public class AddressResponseDto
    {
        public Guid Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
    }
}
