using CotizaConstructora.Models;

namespace CotizaConstructora.Core.Contracts
{
    public interface ICotizacionesDomain
    {
        Task<bool> InsertarCotizacion(CotizacionDto cotizacionDto);
    }
}