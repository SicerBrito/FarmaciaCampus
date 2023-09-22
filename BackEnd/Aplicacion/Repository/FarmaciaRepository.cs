using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FarmaciaRepository : GenericRepository<Farmacia>, IFarmacia
{
    private readonly DbAppContext _Context;
    public FarmaciaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
