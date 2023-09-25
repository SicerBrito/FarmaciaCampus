using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly DbAppContext _Context;
    public DepartamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Departamento> GetByPaisAsync(string pais)
    {
        return (await _Context.Set<Departamento>()
                            .Include(u => u.Paises)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==pais.ToLower()))!;
    }
}
