using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentosVendidosRepository : GenericRepository<MedicamentosVendidos>, IMedicamentosVendidos
{
    private readonly DbAppContext _Context;
    public MedicamentosVendidosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
