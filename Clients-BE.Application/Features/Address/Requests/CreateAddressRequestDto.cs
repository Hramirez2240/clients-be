namespace Clients_BE.Application.Features.Address.Requests
{
    public class CreateAddressRequestDto
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
    }
}
