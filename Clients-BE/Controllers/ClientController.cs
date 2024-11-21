using Clients_BE.Application.Common;
using Clients_BE.Application.Features.Client.Requests;
using Clients_BE.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clients_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get clients list")]
        public IActionResult ListClients()
        {
            var result = _clientService.ListClients();

            return Ok(BaseResponse.Ok(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get client by id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _clientService.GetClientById(id);

            return Ok(BaseResponse.Ok(result));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new client")]
        public async Task<IActionResult> Post([FromBody] CreateClientRequestDto request, CancellationToken cancellationToken = default)
        {
            var result = await _clientService.CreateClient(request, cancellationToken);

            return Ok(BaseResponse.Ok(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing client")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateClientRequestDto request)
        {
            var result = await _clientService.UpdateClient(id, request);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes an specific client")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _clientService.DeleteClientById(id);
            return Ok(BaseResponse.Ok(result));
        }
    }
}
