using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IProveedor : IGenericRepository<Proveedor>{
        
        //! Consulta Nro. 2
        Task<List<Proveedor>> ListarProveedoresConInformacionDeContacto();

        //! Consulta Nro.13
        Task<List<Proveedor>> ObtenerProveedoresQueNoHanVendidoEnUltimoAnio();
    }
