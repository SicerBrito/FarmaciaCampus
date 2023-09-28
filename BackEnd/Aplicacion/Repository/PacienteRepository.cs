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
                                .Include(p => p.HistorialesMedicos)
                                .Include(p => p.FormulasMedicas)
                                .ToListAsync();
    }

    //! Consulta Nro.12
    public async Task<List<Paciente>> ObtenerPacientesQueHanCompradoParacetamol()
    {
        var pacientes = await _Context.Pacientes!
            .Where(paciente => paciente.FormulasMedicas!
                .Any(formula => formula.FormulaMedicamentos!
                    .Any(fm => fm.Medicamentos!.Nombre == "Paracetamol")))
            .ToListAsync();

        return pacientes;
    }

    //! Consulta Nro.22
    public async Task<Paciente?> ObtenerPacienteMayorGasto2023()
    {
        var primerDia2023 = new DateTime(2023, 1, 1);
        var ultimoDia2023 = new DateTime(2023, 12, 31, 23, 59, 59);

        var pacienteMayorGasto2023 = await _Context.Ventas!
            .Where(v => v.FechaVenta >= primerDia2023 && v.FechaVenta <= ultimoDia2023)
            .GroupBy(v => v.Usuarios!.Id)
            .Select(g => new
            {
                Paciente = g.Select(v => v.Usuarios!.Ventas).FirstOrDefault(), // Acceder al paciente asociado al usuario si existe
                TotalGasto = g.Sum(v => v.Inventarios!.Sum(i => i.Ventas!.MedicamentosVendidos!
                    .Sum(mv => mv.CantidadVendida * Convert.ToDecimal(mv.Medicamentos!.ValorUnidad))))
            })
            .OrderByDescending(x => x.TotalGasto)
            .Select(x => x.Paciente)
            .FirstOrDefaultAsync();

        return pacienteMayorGasto2023;
    }

    public async Task<Paciente> GetByGeneroAsync(string genero)
    {
        return (await _Context.Set<Paciente>()
                            .Include(u => u.Generos)
                            .FirstOrDefaultAsync(u => u.Apellidos!.ToLower()==genero.ToLower()))!;
    }
}
