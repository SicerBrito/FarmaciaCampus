using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly DbAppContext _Context;
    public MedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
