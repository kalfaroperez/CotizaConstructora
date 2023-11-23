using CotizaConstructora.Core.Contracts;
using CotizaConstructora.Entities;
using CotizaConstructora.Models;
using CotizaConstructora.Persistance;
using CotizaConstructora.Persistance.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Core
{
    public class MaterialesDomain : IMaterialesDomain
    {
        private readonly IMaterialesRepository _materialesRepository;

        public MaterialesDomain(IMaterialesRepository materialesRepository)
        {
            _materialesRepository = materialesRepository;
        }

        public async Task<bool> InsertarMaterial(MaterialDto materialDto)
        {
            var material = new Material();
            material.Codigo = materialDto.Codigo;
            material.Descripcion = materialDto.Descripcion;
            material.UnidadMedida = materialDto.UnidadMedida;
            material.CostoUnidad = materialDto.CostoUnidad;
            material.FechaActualizacion = DateTime.Now;

            return await _materialesRepository.GuardarMaterial(material);
        }
    }
}
