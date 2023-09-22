using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly DbAppContext _Context;
    public CitaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
