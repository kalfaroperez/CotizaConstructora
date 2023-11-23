using System.Data;
using CotizaConstructora.Entities;
using CotizaConstructora.Persistance.Contracts;
using Dapper;

namespace CotizaConstructora.Persistance
{
    public class MaterialesRepository : IMaterialesRepository
    {
        public readonly DapperContext _dapperContext;

        public MaterialesRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<bool> GuardarMaterial(Material material)
        {
            using var connection = _dapperContext.Connect();

            var parameters = new DynamicParameters();
            parameters.Add("@Codigo", material.Codigo);
            parameters.Add("@Descripcion", material.Descripcion);
            parameters.Add("@CostoUnidad", material.CostoUnidad);
            parameters.Add("@UnidadMedida", material.UnidadMedida);
            parameters.Add("@FechaActualizacion", DateTime.Now);

            var query = $@"INSERT INTO `materiales`
                                (`Codigo`,
                                `Descripcion`,
                                `UnidadMedida`,
                                `CostoUnidad`,
                                `FechaActualizacion`)
                            VALUES
                                (@Codigo,
                                @Descripcion,
                                @UnidadMedida,
                                @CostoUnidad,
                                @FechaActualizacion);";

            return await connection.ExecuteAsync(query, parameters, commandType: CommandType.Text) > 0;

        }
    }
}
