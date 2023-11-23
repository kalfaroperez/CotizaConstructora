using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Models;
using Microsoft.AspNetCore.Mvc;

namespace CotizaConstructora.WebApi.Controllers
{
    public class ContizacionController : ControllerBase
    {
        private readonly ICotizacionesDomain _cotizacionesDomain;

        public ContizacionController(ICotizacionesDomain cotizacionesDomain)
        {
            _cotizacionesDomain = cotizacionesDomain;
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult<bool>> SaveCotizacion([FromBody] CotizacionDto cotizacionDto)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response =  await _cotizacionesDomain.InsertarCotizacion(cotizacionDto);
            return Ok(response);
        }
    }
}
