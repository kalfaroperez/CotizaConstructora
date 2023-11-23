using CotizaConstructora.Entities;

namespace CotizaConstructora.Persistance.Contracts
{
    public interface IClienteRepository
    {
        public Task<bool> GuardarCliente(Cliente cliente);

        public Task<Cliente> ConsultarClientePorIdentificacion(string identificacion);
    }
}