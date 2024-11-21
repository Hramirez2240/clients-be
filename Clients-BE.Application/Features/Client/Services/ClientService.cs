using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clients_BE.Application.Common.Exceptions;
using Clients_BE.Application.Features.Client.Requests;
using Clients_BE.Application.Features.Client.Responses;
using Clients_BE.Application.Interfaces;
using Clients_BE.Application.Interfaces.Services;
using ClientEntity = Clients_BE.Domain.Entities.Client;

namespace Clients_BE.Application.Features.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<ClientEntity> _addressRepository;
        private readonly IMapper _mapper;

        public ClientService(IBaseRepository<ClientEntity> clientRepository, IMapper mapper)
        {
            _addressRepository = clientRepository;
            _mapper = mapper;
        }

        public List<ClientResponseDto> ListClients()
        {
            var query = _addressRepository.Query().OrderByDescending(x => x.CreatedDate);
            var clientResponseDto = query.ProjectTo<ClientResponseDto>(_mapper.ConfigurationProvider).ToList();

            return clientResponseDto;
        }

        public async Task<ClientResponseDto> GetClientById(Guid id)
        {
            var client = await _addressRepository.GetById(id) ?? throw new NotFoundException("Client", id);
            var clientResponseDto = _mapper.Map<ClientResponseDto>(client);

            return clientResponseDto;
        }

        public async Task<ClientResponseDto> CreateClient(CreateClientRequestDto request, CancellationToken cancellationToken = default)
        {
            bool isClientExists = _addressRepository.Query().Any(x => x.UserName == request.UserName);
            if (isClientExists) throw new BadRequestException($"El usuario: {request.UserName} ya existe");

            var clientEntity = _mapper.Map<ClientEntity>(request);
            var client = await _addressRepository.AddAsync(clientEntity, cancellationToken);
            var response = _mapper.Map<ClientResponseDto>(client);

            return response;
        }

        public async Task<ClientResponseDto> UpdateClient(Guid id, UpdateClientRequestDto request)
        {
            bool isClientExists = _addressRepository.Query().Any(x => x.Id == id);
            if(!isClientExists) throw new NotFoundException("Client", id);

            request.Id = id;
            var client = _mapper.Map<ClientEntity>(request);
            var result = await _addressRepository.UpdateAsync(client);
            var dto = _mapper.Map<ClientResponseDto>(result);

            return dto;
        }

        public async Task<bool> DeleteClientById(Guid id)
        {
            try
            {
                bool isClientExists = _addressRepository.Query().Any(x => x.Id == id);
                if (!isClientExists) throw new NotFoundException("Client", id);

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
