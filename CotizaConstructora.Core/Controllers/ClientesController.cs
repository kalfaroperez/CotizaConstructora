using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Models;
using Microsoft.AspNetCore.Mvc;

namespace CotizaConstructora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteDomain _clienteDomain;

        public ClientesController(IClienteDomain clienteDomain)
        {
            _clienteDomain = clienteDomain;
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult<bool>> SaveCliente([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _clienteDomain.InsertarCliente(clienteDto);
            return Ok(response);
        }
    }
}
