using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoMedicamentoRepository : GenericRepository<TipoMedicamento>, ITipoMedicamento
{
    private readonly DbAppContext _Context;
    public TipoMedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
