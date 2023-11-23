using CotizaConstructora.Models;

namespace CotizaConstructora.Core.Contracts
{
    public interface IClienteDomain
    {
        public Task<bool> InsertarCliente(ClienteDto cliente);
    }
}