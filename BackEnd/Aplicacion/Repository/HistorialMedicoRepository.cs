using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class HistorialMedicoRepository : GenericRepository<HistorialMedico>, IHistorialMedico
{
    private readonly DbAppContext _Context;
    public HistorialMedicoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
