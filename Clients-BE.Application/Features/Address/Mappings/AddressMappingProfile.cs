using AutoMapper;
using Clients_BE.Application.Features.Address.Requests;
using Clients_BE.Application.Features.Address.Responses;
using AddressEntity = Clients_BE.Domain.Entities.Address;

namespace Clients_BE.Application.Features.Address.Mappings
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            {
                CreateMap<AddressEntity, AddressResponseDto>();
                CreateMap<CreateAddressRequestDto, AddressEntity>();
                CreateMap<UpdateAddressRequestDto, AddressEntity>();
            }
        }
    }
}
