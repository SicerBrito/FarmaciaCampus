using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IInventario : IGenericRepository<Inventario>{
        Task<Inventario> GetByFarmaciaAsync (string farmacia);
        Task<Inventario> GetByCompraAsync (string compra);
        Task<Inventario> GetByVentaAsync (string venta);
    }
