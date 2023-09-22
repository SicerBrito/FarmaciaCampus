using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly DbAppContext _Context;
    public VentaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
