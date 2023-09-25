using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface ICompra : IGenericRepository<Compra>{
        Task<Compra> GetByProveedorAsync(string proveedor);
        Task<Compra> GetByMetodoDePagoAsync(string metododepago);
    }
