using Clients_BE.Application.Features.Address.Requests;
using Clients_BE.Application.Features.Address.Responses;

namespace Clients_BE.Application.Interfaces.Services
{
    public interface IAddressService
    {
        List<AddressResponseDto> ListAddress();
        List<AddressResponseDto> ListAddressByClientId(Guid id);
        Task<AddressResponseDto> GetAddressById(Guid id);
        Task<AddressResponseDto> CreateAddress(CreateAddressRequestDto request, CancellationToken cancellationToken = default);
        Task<AddressResponseDto> UpdateAddress(Guid id, UpdateAddressRequestDto request);
        Task<bool> DeleteAddressById(Guid id);
    }
}
