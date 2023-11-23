using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Entities;
using CotizaConstructora.Models;
using CotizaConstructora.Persistance.Contracts;

namespace CotizaConstructora.Domain
{
    public class ClienteDomain : IClienteDomain
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomain(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> InsertarCliente(ClienteDto clienteDto)
        {
            
            var cliente = new Cliente();
            cliente.Identificacion = clienteDto.Identificacion;
            cliente.Nombres = clienteDto.Nombres;
            cliente.Apellidos = clienteDto.Apellidos;
            cliente.Telefono = clienteDto.Telefono;

            var result =  await _clienteRepository.GuardarCliente(cliente);
            
            return result;
        }
    }
}