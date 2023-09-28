using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IProveedor : IGenericRepository<Proveedor>{
        Task<List<Proveedor>> ListarProveedoresConInformacionDeContacto();
    }
