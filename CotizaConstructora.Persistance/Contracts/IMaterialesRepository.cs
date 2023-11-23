using CotizaConstructora.Entities;

namespace CotizaConstructora.Persistance.Contracts
{
    public interface IMaterialesRepository
    {
        public Task<bool> GuardarMaterial(Material material);
    }
}