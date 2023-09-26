using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IMedicamentosVendidos : IGenericRepository<MedicamentosVendidos>{
        Task<MedicamentosVendidos> GetByVentaAsync (string venta);
        Task<MedicamentosVendidos> GetByMedicamentoAsync (string medicamento);
    }
