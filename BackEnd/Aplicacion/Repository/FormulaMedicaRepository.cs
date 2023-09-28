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

    //! Consulta Nro.4
    public async Task<List<FormulaMedica>> ObtenerRecetasMedicasEmitidasDespuesDe2023()
    {
        DateTime fechaLimite = new DateTime(2023, 1, 1);

        var recetasDespuesDe2023 = await _Context.FormulasMedicas!
            .Where(r => r.FechaPrescripcion > fechaLimite)
            .ToListAsync();

        return recetasDespuesDe2023;
    }
    public override async Task<IEnumerable<FormulaMedica>> GetAllAsync()
    {
        return await _Context.Set<FormulaMedica>()
                                .Include(p => p.Pacientes)
                                .Include(p => p.Empleados)
                                .Include(p => p.FormulaMedicamentos)
                                .ToListAsync();
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
