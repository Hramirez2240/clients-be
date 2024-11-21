using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clients_BE.Application.Common.Exceptions;
using Clients_BE.Application.Features.Address.Requests;
using Clients_BE.Application.Features.Address.Responses;
using Clients_BE.Application.Interfaces;
using Clients_BE.Application.Interfaces.Services;
using AddressEntity = Clients_BE.Domain.Entities.Address;

namespace Clients_BE.Application.Features.Address.Services
{
    public class AddressService : IAddressService
    {
        private readonly IBaseRepository<AddressEntity> _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IBaseRepository<AddressEntity> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public List<AddressResponseDto> ListAddress()
        {
            var query = _addressRepository.Query().OrderByDescending(x => x.CreatedDate);
            var addressResponseDto = query.ProjectTo<AddressResponseDto>(_mapper.ConfigurationProvider).ToList();

            return addressResponseDto;
        }

        public List<AddressResponseDto> ListAddressByClientId(Guid id)
        {
            var query = _addressRepository.Query().Where(x => x.ClientId == id);

            var addressResponseDto = query.ProjectTo<AddressResponseDto>(_mapper.ConfigurationProvider).ToList();
            return addressResponseDto;
        }

        public async Task<AddressResponseDto> GetAddressById(Guid id)
        {
            var address = await _addressRepository.GetById(id) ?? throw new NotFoundException("Address", id);
            var addressResponseDto = _mapper.Map<AddressResponseDto>(address);

            return addressResponseDto;
        }

        public async Task<AddressResponseDto> CreateAddress(CreateAddressRequestDto request, CancellationToken cancellationToken = default)
        {
            var addressEntity = _mapper.Map<AddressEntity>(request);
            var address = await _addressRepository.AddAsync(addressEntity, cancellationToken);
            var response = _mapper.Map<AddressResponseDto>(address);

            return response;
        }

        public async Task<AddressResponseDto> UpdateAddress(Guid id, UpdateAddressRequestDto request)
        {
            bool isAddressExists = _addressRepository.Query().Any(x => x.Id == id);
            if (!isAddressExists) throw new NotFoundException("Address", id);

            request.Id = id;
            var address = _mapper.Map<AddressEntity>(request);
            var result = await _addressRepository.UpdateAsync(address);
            var dto = _mapper.Map<AddressResponseDto>(result);

            return dto;
        }

        public async Task<bool> DeleteAddressById(Guid id)
        {
            try
            {
                bool isAddressExists = _addressRepository.Query().Any(x => x.Id == id);
                if (!isAddressExists) throw new NotFoundException("Address", id);

                await _addressRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
