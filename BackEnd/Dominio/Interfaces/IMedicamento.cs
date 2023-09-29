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

        // !Consulta Nro.9
        Task<IEnumerable<Medicamento>> ObtenerMedicamentosNoVendidos();
    
        //! Consulta Nro.10
        Task<Medicamento> ObtenerMedicamentoMasCaro();

        //! Consulta Nro.11
        Task<Dictionary<string, int>> ObtenerNumeroMedicamentosPorProveedor();
    
        //! Consulta Nro.19
        Task<List<Medicamento>> ObtenerMedicamentosQueExpiranEn2024();

        //! Consulta Nro.21
        Task<List<Medicamento>> ObtenerMedicamentosNuncaVendidos();

        //! Consulta Nro.31
        Task<Dictionary<string, List<Medicamento>>> ObtenerMedicamentosVendidosPorMesEn2023();
    
        //! Consulta Nro.34
        Task<List<Medicamento>> ObtenerMedicamentosNoVendidosEn2023();

        //! Consulta Nro.38
        Task<List<Medicamento>> ObtenerMedicamentosPrecioStock();

    }
