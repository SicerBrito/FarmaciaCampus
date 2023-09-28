using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IMedicamento : IGenericRepository<Medicamento>{
        Task<Medicamento> GetByTipoMedicamentoAsync (string tipoMedicamento);
        Task<Medicamento> GetByCategoriaMedicamentoAsync (string categoriaMedicamento);
        Task<Medicamento> GetByPresentacionAsync (string presentacion);
        Task<Medicamento> GetByProveedorAsync (string proveedor);

        //! Consulta Nro.1
        IQueryable<Medicamento> GetAllMedicamentos(); // Método para obtener todos los medicamentos.
        
        //! Consulta Nro.3
        Task<IEnumerable<Medicamento?>> ObtenerMedicamentosCompradosPorProveedorId(int proveedorId);
        
        //! Consulta Nro.6
        Task<List<Medicamento>> ObtenerMedicamentosCaducanAntesDe2024();
    
        //! Consulta Nro.7
        // Task<Dictionary<string, int>> ObtenerTotalMedicamentosVendidosPorProveedor();
    
        Task<IEnumerable<object>> ObtenerTotalMedicamentosVendidosPorProveedor();
    }
