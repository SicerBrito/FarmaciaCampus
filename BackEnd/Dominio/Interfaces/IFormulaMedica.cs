using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IFormulaMedica : IGenericRepository<FormulaMedica>{
        Task<FormulaMedica> GetByPacienteAsync (string paciente);
        Task<FormulaMedica> GetByMedicoAsync (string medico);
    }
