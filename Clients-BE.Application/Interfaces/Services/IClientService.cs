using Clients_BE.Application.Features.Client.Requests;
using Clients_BE.Application.Features.Client.Responses;

namespace Clients_BE.Application.Interfaces.Services
{
    public interface IClientService
    {
        List<ClientResponseDto> ListClients();
        Task<ClientResponseDto> GetClientById(Guid id);
        Task<ClientResponseDto> CreateClient(CreateClientRequestDto request, CancellationToken cancellationToken = default);
        Task<ClientResponseDto> UpdateClient(Guid id, UpdateClientRequestDto request);
        Task<bool> DeleteClientById(Guid id);
    }
}
