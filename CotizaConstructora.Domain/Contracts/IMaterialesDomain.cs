using CotizaConstructora.Models;

namespace CotizaConstructora.Core.Contracts
{
    public interface IMaterialesDomain
    {
        public Task<bool> InsertarMaterial(MaterialDto materialDto);
    }
}