using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MetodoDePagoRepository : GenericRepository<MetodoDePago>, IMetodoDePago
{
    private readonly DbAppContext _Context;
    public MetodoDePagoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}