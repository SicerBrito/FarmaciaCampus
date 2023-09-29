using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IEmpleado : IGenericRepository<Empleado>{
        Task<Empleado> GetByFarmaciaAsync (string farmacia);
        Task<Empleado> GetByCargoAsync (string cargo);

        //! Consulta Nro.20
        Task<List<Empleado>> ObtenerEmpleadosConMasDe5Ventas();

        //! Consulta Nro.23
        Task<List<Empleado>> ObtenerEmpleadosSinVentasEn2023();

        //! Consulta Nro.32
        Task<Empleado> ObtenerEmpleadoMayorCantidadMedicamentosVendidosEn2023();
    }
