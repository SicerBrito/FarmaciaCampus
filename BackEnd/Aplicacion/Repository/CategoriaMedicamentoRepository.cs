using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CategoriaMedicamentoRepository : GenericRepository<CategoriaMedicamento>, ICategoriaMedicamento
{
    private readonly DbAppContext _Context;
    public CategoriaMedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
