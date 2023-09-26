using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IPaciente : IGenericRepository<Paciente>{
        Task<Paciente> GetByGeneroAsync (string genero);
    }
