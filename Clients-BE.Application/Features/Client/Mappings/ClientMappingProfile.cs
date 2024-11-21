using AutoMapper;
using Clients_BE.Application.Features.Client.Requests;
using Clients_BE.Application.Features.Client.Responses;
using ClientEntity = Clients_BE.Domain.Entities.Client;

namespace Clients_BE.Application.Features.Client.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientEntity, ClientResponseDto>();
            CreateMap<CreateClientRequestDto, ClientEntity>();
            CreateMap<UpdateClientRequestDto, ClientEntity>();
        }
    }
}
