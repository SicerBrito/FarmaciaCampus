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
    public async Task<Paciente> ObtenerPacienteMayorGasto2023()
    {
        var pacienteMayorGasto2023 = await _Context.Pacientes!
            .Where(p => p.FormulasMedicas!
                .Any(fm => fm.FechaPrescripcion.Year == 2023))
            .OrderByDescending(p => p.FormulasMedicas!
                .Where(fm => fm.FechaPrescripcion.Year == 2023)
                .Sum(fm => fm.FormulaMedicamentos!
                    .Sum(fm => fm.Medicamentos!.MedicamentosVendidos!
                        .Where(mv => mv.Ventas!.FechaVenta.Year == 2023)
                        .Sum(mv => mv.CantidadVendida * Convert.ToDouble(mv.Medicamentos!.ValorUnidad)))))
            .FirstOrDefaultAsync();

        return pacienteMayorGasto2023!;
    }

    //! Consulta Nro.25
    public async Task<List<Paciente>> ObtenerPacientesQueCompraronParacetamolEn2023()
    {
        var pacientesQueCompraronParacetamolEn2023 = await _Context.Pacientes!
            .Where(p => p.FormulasMedicas!
                .Any(fm => fm.FormulaMedicamentos!
                    .Any(fmd => fmd.Medicamentos!.Nombre == "Paracetamol" && fmd.FormulasMedicas!.FechaPrescripcion.Year == 2023)))
            .ToListAsync();

        return pacientesQueCompraronParacetamolEn2023;
    }

    //! Consulta Nro.30
    public async Task<List<Paciente>> ObtenerPacientesSinComprasEn2023()
    {
        var pacientesSinComprasEn2023 = await _Context.Pacientes!
            .Where(p => !_Context.Ventas!.Any(v => v.ClienteId == p.Id && v.FechaVenta.Year == 2023))
            .ToListAsync();

        return pacientesSinComprasEn2023;
    }

    //! Consulta Nro.33
    public async Task<Dictionary<string, decimal>> ObtenerTotalGastadoPorPacienteEn2023()
    {
        var gastosPorPaciente = await _Context.Pacientes!
            .Include(p => p.FormulasMedicas!)
            .ThenInclude(fm => fm.FormulaMedicamentos)
            .Where(p => p.FormulasMedicas!.Any(fm => fm.FechaPrescripcion.Year == 2023))
            .ToDictionaryAsync(
                p => $"{p.Nombres} {p.Apellidos}",
                p => p.FormulasMedicas!
                    .Where(fm => fm.FechaPrescripcion.Year == 2023)
                    .SelectMany(fm => fm.FormulaMedicamentos!)
                    .Sum(fm => (fm.Medicamentos?.MedicamentosVendidos?.Sum(mv => mv.CantidadVendida * decimal.Parse(mv.ValorTotalVenta ?? "0")) ?? 0))
            );

        return gastosPorPaciente;
    }

    public async Task<Paciente> GetByGeneroAsync(string genero)
    {
        return (await _Context.Set<Paciente>()
                            .Include(u => u.Generos)
                            .FirstOrDefaultAsync(u => u.Apellidos!.ToLower()==genero.ToLower()))!;
    }


}
