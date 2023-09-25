using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly DbAppContext _Context;
    public CiudadRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Ciudad> GetByDepartamentoAsync(string departamento)
    {
        return (await _Context.Set<Ciudad>()
                            .Include(u => u.Departamentos)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==departamento.ToLower()))!;
    }
}
