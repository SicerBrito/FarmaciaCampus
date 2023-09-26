using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class HistorialMedicoRepository : GenericRepository<HistorialMedico>, IHistorialMedico
{
    private readonly DbAppContext _Context;
    public HistorialMedicoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<HistorialMedico> GetByMedicoAsync(string medico)
    {
        return (await _Context.Set<HistorialMedico>()
                            .Include(u => u.Empleados)
                            .FirstOrDefaultAsync(u => u.Diagnostico!.ToLower()==medico.ToLower()))!;
    }

    public async Task<HistorialMedico> GetByPacienteAsync(string paciente)
    {
        return (await _Context.Set<HistorialMedico>()
                            .Include(u => u.Pacientes)
                            .FirstOrDefaultAsync(u => u.Diagnostico!.ToLower()==paciente.ToLower()))!;
    }
}
