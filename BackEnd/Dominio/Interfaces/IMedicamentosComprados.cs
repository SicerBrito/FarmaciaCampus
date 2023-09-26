using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IMedicamentosComprados : IGenericRepository<MedicamentosComprados>{
        Task<MedicamentosComprados> GetByComprasAsync (string compras);
        Task<MedicamentosComprados> GetByMedicamentoAsync (string medicamento);
    }
