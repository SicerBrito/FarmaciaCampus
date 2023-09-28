using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IVenta : IGenericRepository<Venta>{
        Task<Venta> GetByClienteAsync (string cliente);
        Task<Venta> GetByEmpleadoAsync (string empleado);
        Task<Venta> GetByMetodoDePagoAsync (string metodoDePago);

        //! Consulta Nro.5
        Task<decimal> ObtenerTotalVentasParacetamol();
    }
