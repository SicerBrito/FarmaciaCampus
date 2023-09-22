using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FormulaMedicaRepository : GenericRepository<FormulaMedica>, IFormulaMedica
{
    private readonly DbAppContext _Context;
    public FormulaMedicaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
