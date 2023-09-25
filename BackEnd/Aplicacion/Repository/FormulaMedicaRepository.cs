using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FormulaMedicaRepository : GenericRepository<FormulaMedica>, IFormulaMedica
{
    private readonly DbAppContext _Context;
    public FormulaMedicaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<FormulaMedica> GetByMedicoAsync(string medico)
    {
        return (await _Context.Set<FormulaMedica>()
                            .Include(u => u.Empleados)
                            .FirstOrDefaultAsync(u => u.FechaPrescripcion!.ToString()==medico.ToLower()))!;
    }

    public async Task<FormulaMedica> GetByPacienteAsync(string paciente)
    {
        return (await _Context.Set<FormulaMedica>()
                            .Include(u => u.Pacientes)
                            .FirstOrDefaultAsync(u => u.FechaPrescripcion!.ToString()==paciente.ToLower()))!;
    }
}
