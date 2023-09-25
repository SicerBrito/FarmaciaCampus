using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FormulaMedicamentosRepository : GenericRepository<FormulaMedicamentos>, IFormulaMedicamentos
{
    private readonly DbAppContext _Context;
    public FormulaMedicamentosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
