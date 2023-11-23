using CotizaConstructora.Entities;
using CotizaConstructora.Models;

namespace CotizaConstructora.Persistance.Contracts
{
    public interface ICotizacionesRepository
    {
        public Task<bool> InsertarCotizacion(CotizacionDto cotizacion);
    }
}