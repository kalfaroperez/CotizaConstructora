using System.Data;
using CotizaConstructora.Entities;
using CotizaConstructora.Models;
using CotizaConstructora.Persistance.Contracts;
using Dapper;

namespace CotizaConstructora.Persistance
{
    public class CotizacionesRepository : ICotizacionesRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly IClienteRepository _clienteRepository;

        public CotizacionesRepository(DapperContext dapperContext, IClienteRepository clienteRepository)
        {
            _dapperContext = dapperContext;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> InsertarCotizacion(CotizacionDto cotizacion)
        {
            var identificacion = cotizacion.Cliente.Identificacion;

            using var connection = _dapperContext.Connect();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var cliente = await _clienteRepository.ConsultarClientePorIdentificacion(identificacion);

                var parameters = new DynamicParameters();
                parameters.Add("@Numero", cotizacion.Numero);
                parameters.Add("@Fecha", cotizacion.Fecha);
                parameters.Add("@Estado", cotizacion.Estado);
                parameters.Add("@Total", cotizacion.Total);
                parameters.Add("@Subtotal", cotizacion.Subtotal);
                parameters.Add("@IVA", cotizacion.IVA);
                parameters.Add("@IdCliente", cliente.IdCliente);

                var query = @$" 
                INSERT INTO cotizaciones
                    (`Numero`,
                    `Fecha`,
                    `Estado`,
                    `Total`,
                    `Subtotal`,
                    `IVA`,
                    `IdCliente`)
                VALUES
                    (@Numero,
                    @Fecha,
                    @Estado,
                    @Total,
                    @Subtotal,
                    @IVA,
                    @IdCliente); 

                    SELECT LAST_INSERT_ID();
            ";

                var idCotizacion = connection.ExecuteScalar<long>(query, parameters, transaction: transaction, commandType: CommandType.Text);

                var insertDetalle = string.Empty;

                foreach (var material in cotizacion.Materiales)
                {
                    var parametersDetail = new DynamicParameters();
                    parametersDetail.Add("@IdCotizacion", idCotizacion);
                    parametersDetail.Add("@IdMaterial", material.IdMaterial);
                    parametersDetail.Add("@Valor", material.Valor);
                    parametersDetail.Add("@Cantidad", material.Cantidad);
                    parametersDetail.Add("@Subtotal", material.Subtotal);
                    parametersDetail.Add("@IVA", material.IVA);
                    parametersDetail.Add("@Total", material.Total);

                    insertDetalle = $@"INSERT INTO contizaciondetalles
                                        (IdCotizacion,
                                        IdMaterial,
                                        Valor,
                                        Cantidad,
                                        Subtotal,
                                        Total,
                                        Iva
                                        )
                                    VALUES
                                        (@IdCotizacion, 
                                        @IdMaterial,
                                        @Valor,
                                        @Cantidad,
                                        @Subtotal,
                                        @Total,
                                        @IVA);";

                    await connection.ExecuteAsync(insertDetalle, parametersDetail, commandType: CommandType.Text);
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }

        }

        //public async Task<CotizacionDto> ConsultarCotizacion(string numero)
        //{
        //    using var connection = _dapperContext.Connect();

        //    try
        //    {

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Numero", numero);

        //        var query = @$" 
        //        SELECT 
        //            Numero,
        //            Fecha,
        //            Estado,
        //            Total,
        //            Subtotal,
        //            IVA,
        //            IdCliente
        //        FROM cotizaciones
        //        WHERE Numero=@Numero;
        //    ";
        //        var cotization = await connection.QueryAsync<Cotizacion>(query, parameters, commandType: CommandType.Text);

        //        if (cotization != null)
        //        {
        //            var queryDetalle = @$" 
        //                SELECT 
        //                    Numero,
        //                    Fecha,
        //                    Estado,
        //                    Total,
        //                    Subtotal,
        //                    IVA,
        //                    IdCliente
        //                FROM cotizaciondetalles
        //                WHERE Numero=@Numero;
        //            ";
        //            var cotization = await connection.QueryAsync<CotizacionDetalle>(query, parameters, commandType: CommandType.Text);
        //        }

        //        var idCotizacion = connection.ExecuteScalar<long>(query, parameters, commandType: CommandType.Text);

        //        var insertDetalle = string.Empty;

        //        foreach (var material in cotizacion.Materiales)
        //        {
        //            var parametersDetail = new DynamicParameters();
        //            parametersDetail.Add("@IdCotizacion", idCotizacion);
        //            parametersDetail.Add("@IdMaterial", material.IdMaterial);
        //            parametersDetail.Add("@Valor", material.Valor);
        //            parametersDetail.Add("@Cantidad", material.Cantidad);
        //            parametersDetail.Add("@Subtotal", material.Subtotal);
        //            parametersDetail.Add("@IVA", material.IVA);
        //            parametersDetail.Add("@Total", material.Total);

        //            insertDetalle = $@"INSERT INTO contizaciondetalles
        //                                (IdCotizacion,
        //                                IdMaterial,
        //                                Valor,
        //                                Cantidad,
        //                                Subtotal,
        //                                Total,
        //                                Iva
        //                                )
        //                            VALUES
        //                                (@IdCotizacion, 
        //                                @IdMaterial,
        //                                @Valor,
        //                                @Cantidad,
        //                                @Subtotal,
        //                                @Total,
        //                                @IVA);";

        //            await connection.ExecuteAsync(insertDetalle, parametersDetail, commandType: CommandType.Text);
        //        }

        //        transaction.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        return false;
        //    }

        //}
    }
}
