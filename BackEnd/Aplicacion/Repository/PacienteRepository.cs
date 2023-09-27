using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PacienteRepository : GenericRepository<Paciente>, IPaciente
{
    private readonly DbAppContext _Context;
    public PacienteRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Paciente>> GetAllAsync()
    {
        return await _Context.Set<Paciente>()
                                .Include(p => p.Generos)
                                .ToListAsync();
    }

    public async Task<Paciente> GetByGeneroAsync(string genero)
    {
        return (await _Context.Set<Paciente>()
                            .Include(u => u.Generos)
                            .FirstOrDefaultAsync(u => u.Apellidos!.ToLower()==genero.ToLower()))!;
    }
}
