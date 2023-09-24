using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly DbAppContext _Context;
    public CitaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Cita> GetByCitaAsync(string estado)
    {
        return (await _Context.Set<Cita>()
                            .Include(u => u.EstadoCitas)
                            .FirstOrDefaultAsync(u => u.!.ToLower()==estado.ToLower()))!;
    }

    public async Task<Cita> GetByMedicoAsync(string medico)
    {
        throw new NotImplementedException();
    }

    public async Task<Cita> GetByUsuarioAsync(string usuario)
    {
        throw new NotImplementedException();
    }
}
