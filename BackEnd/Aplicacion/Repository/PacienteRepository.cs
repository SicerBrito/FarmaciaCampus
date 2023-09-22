using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PacienteRepository : GenericRepository<Paciente>, IPaciente
{
    private readonly DbAppContext _Context;
    public PacienteRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
