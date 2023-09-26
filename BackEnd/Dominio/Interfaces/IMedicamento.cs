using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IMedicamento : IGenericRepository<Medicamento>{
        Task<Medicamento> GetByTipoMedicamentoAsync (string tipoMedicamento);
        Task<Medicamento> GetByCategoriaMedicamentoAsync (string categoriaMedicamento);
        Task<Medicamento> GetByPresentacionAsync (string presentacion);
        Task<Medicamento> GetByProveedorAsync (string proveedor);
    }
