using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IHistorialMedico : IGenericRepository<HistorialMedico>{
        Task<HistorialMedico> GetByPacienteAsync (string paciente);
        Task<HistorialMedico> GetByMedicoAsync (string medico);
    }
