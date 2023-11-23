using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Entities;
using CotizaConstructora.Models;
using CotizaConstructora.Persistance.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Core
{
    public class CotizacionesDomain : ICotizacionesDomain
    {
        private readonly ICotizacionesRepository _cotizacionesRepository;

        public CotizacionesDomain(ICotizacionesRepository cotizacionesRepository)
        {
            _cotizacionesRepository = cotizacionesRepository;
        }

        public async Task<bool> InsertarCotizacion(CotizacionDto cotizacionDto)
        {
            if (cotizacionDto.Materiales.Any())
            {
                return await _cotizacionesRepository.InsertarCotizacion(cotizacionDto);
            }
            else
            {
                return false;
            }
            
        }
    }
}
