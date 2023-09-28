using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IPaciente : IGenericRepository<Paciente>{
        Task<Paciente> GetByGeneroAsync (string genero);

        //! Consulta Nro.12
        Task<List<Paciente>> ObtenerPacientesQueHanCompradoParacetamol();
    
        //! Consulta Nro.22
        Task<Paciente> ObtenerPacienteMayorGasto2023();
    
    
    
    }
