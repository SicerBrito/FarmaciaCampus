using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IPaciente : IGenericRepository<Paciente>{
        Task<Paciente> GetByGeneroAsync (string genero);

        //! Consulta Nro.12
        Task<List<Paciente>> ObtenerPacientesQueHanCompradoParacetamol();
    
        //! Consulta Nro.22
        Task<Paciente> ObtenerPacienteMayorGasto2023();
    
        //! Consulta Nro.25
        Task<List<Paciente>> ObtenerPacientesQueCompraronParacetamolEn2023();
    
        //! Consulta Nro.30
        Task<List<Paciente>> ObtenerPacientesSinComprasEn2023();
    
        //! Consulta Nro.33
        Task<Dictionary<string, decimal>> ObtenerTotalGastadoPorPacienteEn2023();


    }
