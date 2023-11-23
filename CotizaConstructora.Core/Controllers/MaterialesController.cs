using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Models;
using Microsoft.AspNetCore.Mvc;

namespace CotizaConstructora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialesController : ControllerBase
    {
        private readonly IMaterialesDomain _materialesDomain;

        public MaterialesController(IMaterialesDomain materialesDomain)
        {
            _materialesDomain = materialesDomain;
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult<bool>> SaveMaterial([FromBody] MaterialDto materialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _materialesDomain.InsertarMaterial(materialDto);
            return Ok(response);
        }
    }
}
