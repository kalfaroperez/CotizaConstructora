using CotizaConstructora.Entities;
using CotizaConstructora.Persistance.Contracts;
using Dapper;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Persistance
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly DapperContext _dapperContext;

        public ClienteRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Cliente> ConsultarClientePorIdentificacion(string identificacion)
        {
            using var connection = _dapperContext.Connect();

            var parameters = new DynamicParameters();
            parameters.Add("@Identificacion", identificacion);
            
            var query = $@"SELECT idCliente,Identificacion, Nombres, Apellidos, Telefono FROM clientes WHERE Identificacion = @Identificacion";

            return await connection.QueryFirstAsync<Cliente>(query, parameters, commandType: CommandType.Text);
        }

        public async Task<bool> GuardarCliente(Cliente cliente)
        {
            using var connection = _dapperContext.Connect();

            var parameters = new DynamicParameters();
            parameters.Add("@Identificacion", cliente.Identificacion);
            parameters.Add("@Nombres", cliente.Nombres);
            parameters.Add("@Apellidos", cliente.Apellidos);
            parameters.Add("@Telefono", cliente.Telefono);

            var query = $@"INSERT INTO clientes(Identificacion, Nombres, Apellidos, Telefono) 
                                        VALUES (@Identificacion, @Nombres, @Apellidos, @Telefono)";

            return await connection.ExecuteAsync(query, parameters, commandType: CommandType.Text) > 0;

            

        }
    }
}
