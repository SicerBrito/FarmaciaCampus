using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IVenta : IGenericRepository<Venta>{
        Task<Venta> GetByClienteAsync (string cliente);
        Task<Venta> GetByEmpleadoAsync (string empleado);
        Task<Venta> GetByMetodoDePagoAsync (string metodoDePago);

        //! Consulta Nro.5
        Task<decimal> ObtenerTotalVentasParacetamol();

        //! Consulta Nro.8
        Task<double> ObtenerTotalDineroRecaudadoPorVentas();
    
        //! Consulta Nro.14
        Task<int> ObtenerTotalMedicamentosVendidosEnMarzo2023();

        //! Consulta Nro.15
        Task<Medicamento> ObtenerMedicamentoMenosVendidoEn2023();

        //! Consulta Nro.17
        Task<double> CalcularPromedioMedicamentosCompradosPorVenta();

        //! Consulta Nro.18
        Task<Dictionary<string, int>> ObtenerCantidadVentasPorEmpleadoEn2023();

        //! Consulta Nro.26
        Task<Dictionary<string, int>> ObtenerTotalMedicamentosVendidosPorMesEn2023();

        //! Consulta Nro.27
        Task<List<Empleado>> ObtenerEmpleadosConMenosDe5VentasEn2023();

        //! Consulta Nro.36
        Task<int> ObtenerTotalMedicamentosVendidosPrimerTrimestre2023();

        //! Consulta Nro.37
        Task<List<Empleado>> ObtenerEmpleadosSinVentasAbril2023();

    }

