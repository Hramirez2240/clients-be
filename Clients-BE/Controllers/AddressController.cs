using Clients_BE.Application.Common;
using Clients_BE.Application.Features.Address.Requests;
using Clients_BE.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Clients_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get address list")]
        public IActionResult ListAddress()
        {
            var result = _addressService.ListAddress();

            return Ok(BaseResponse.Ok(result));
        }

        [HttpGet("client/{id}")]
        [SwaggerOperation(Summary = "Get address list by client id")]
        public IActionResult ListAddress([FromRoute] Guid id)
        {
            var result = _addressService.ListAddressByClientId(id);

            return Ok(BaseResponse.Ok(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get address by id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _addressService.GetAddressById(id);

            return Ok(BaseResponse.Ok(result));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new address")]
        public async Task<IActionResult> Post([FromBody] CreateAddressRequestDto request, CancellationToken cancellationToken = default)
        {
            var result = await _addressService.CreateAddress(request, cancellationToken);

            return Ok(BaseResponse.Ok(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing address")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateAddressRequestDto request)
        {
            var result = await _addressService.UpdateAddress(id, request);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes an specific address")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _addressService.DeleteAddressById(id);
            return Ok(BaseResponse.Ok(result));
        }
    }
}
