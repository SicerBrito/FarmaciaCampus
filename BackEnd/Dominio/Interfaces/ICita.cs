using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface ICita : IGenericRepository<Cita>{
        Task<Cita> GetByCitaAsync(string estado);
        Task<Cita> GetByMedicoAsync(string medico);
        Task<Cita> GetByUsuarioAsync(string usuario);

    }
