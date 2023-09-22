using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly DbAppContext _Context;
    public DepartamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
