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

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _Context.Set<Cita>()
                                .Include(p => p.EstadoCitas)
                                .Include(p => p.Empleados)
                                .Include(p => p.Usuarios)
                                .ToListAsync();        
    }

    public async Task<Cita> GetByCitaAsync(string estado)
    {
        return (await _Context.Set<Cita>()
                            .Include(u => u.EstadoCitas)
                            .FirstOrDefaultAsync(u => u.EstadoCitaId.ToString()==estado.ToLower()))!;
    }

    public async Task<Cita> GetByMedicoAsync(string medico)
    {
        return (await _Context.Set<Cita>()
                            .Include(u => u.Empleados)
                            .FirstOrDefaultAsync(u => u.MedicoId.ToString()==medico.ToLower()))!;
    }

    public async Task<Cita> GetByUsuarioAsync(string usuario)
    {
        return (await _Context.Set<Cita>()
                            .Include(u => u.Usuarios)
                            .FirstOrDefaultAsync(u => u.UsuarioId.ToString()==usuario.ToLower()))!;
    }
}
