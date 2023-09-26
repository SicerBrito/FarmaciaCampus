using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IFormulaMedicamentos : IGenericRepository<FormulaMedicamentos>{
        Task<FormulaMedicamentos> GetByFormulaMedicamentoAsync (string formulaMedica);
        Task<FormulaMedicamentos> GetByMedicamentoAsync (string medicamento);
    }
