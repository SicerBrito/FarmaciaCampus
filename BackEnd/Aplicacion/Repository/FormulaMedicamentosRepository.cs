using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FormulaMedicamentosRepository : GenericRepository<FormulaMedicamentos>, IFormulaMedicamentos
{
    private readonly DbAppContext _Context;
    public FormulaMedicamentosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<FormulaMedicamentos> GetByFormulaMedicamentoAsync(string formulaMedica)
    {
        return (await _Context.Set<FormulaMedicamentos>()
                            .Include(u => u.FormulasMedicas)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==formulaMedica.ToLower()))!;
    }

    public async Task<FormulaMedicamentos> GetByMedicamentoAsync(string medicamento)
    {
        return (await _Context.Set<FormulaMedicamentos>()
                            .Include(u => u.Medicamentos)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==medicamento.ToLower()))!;
    }
}
