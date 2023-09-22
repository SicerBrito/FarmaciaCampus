using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly DbAppContext _Context;
    public CompraRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
