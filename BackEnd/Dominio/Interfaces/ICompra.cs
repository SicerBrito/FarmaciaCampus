using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface ICompra : IGenericRepository<Compra>{
        Task<Compra> GetByProveedorAsync(string proveedor);
        Task<Compra> GetByMetodoDePagoAsync(string metododepago);
    
        //! Consulta Nro.16
        Task<decimal> ObtenerGananciaTotalPorProveedorEn2023(int proveedorId);
    }
