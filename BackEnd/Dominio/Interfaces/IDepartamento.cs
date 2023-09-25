using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IDepartamento : IGenericRepository<Departamento>{
        Task<Departamento> GetByPaisAsync (string pais);
    }
