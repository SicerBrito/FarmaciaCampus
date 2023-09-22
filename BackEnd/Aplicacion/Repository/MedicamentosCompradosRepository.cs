using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentosCompradosRepository : GenericRepository<MedicamentosComprados>, IMedicamentosComprados
{
    private readonly DbAppContext _Context;
    public MedicamentosCompradosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
