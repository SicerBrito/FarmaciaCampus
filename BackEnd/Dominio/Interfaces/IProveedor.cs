using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IProveedor : IGenericRepository<Proveedor>{
        
        //! Consulta Nro. 2
        Task<List<Proveedor>> ListarProveedoresConInformacionDeContacto();

        //! Consulta Nro.13
        Task<List<Proveedor>> ObtenerProveedoresQueNoHanVendidoEnUltimoAnio();
    
        //! Consulta Nro.24
        Task<Proveedor> ObtenerProveedorConMasSuministrosEn2023();
    
        //! Consulta Nro.28
        Task<int> ObtenerNumeroProveedoresSuministraronMedicamentosEn2023();

        //! Consulta Nro.29
        Task<List<Proveedor>> ObtenerProveedoresDeMedicamentosConStockBajo();

        //! Consulta Nro.35
        Task<List<Proveedor>> ObtenerProveedoresCon5MedicamentosDiferentesEn2023();

    }
