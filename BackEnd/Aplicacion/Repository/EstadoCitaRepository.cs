using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class EstadoCitaRepository : GenericRepository<EstadoCita>, IEstadoCita
{
    private readonly DbAppContext _Context;
    public EstadoCitaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
