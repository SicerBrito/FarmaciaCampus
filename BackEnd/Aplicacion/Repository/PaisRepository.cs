using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly DbAppContext _Context;
    public PaisRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
