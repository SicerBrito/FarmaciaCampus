using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly DbAppContext _Context;
    public VentaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _Context.Set<Venta>()
                                .Include(p => p.Usuarios)
                                .Include(p => p.Empleados)
                                .Include(p => p.MetodosDePagos)
                                .Include(p => p.Inventarios)
                                .Include(p => p.MedicamentosVendidos)
                                .ToListAsync();
    }

    //! Consulta Nro.5
    public async Task<decimal> ObtenerTotalVentasParacetamol()
    {
        var totalVentasParacetamol = await _Context.Medicamentos!
            .Where(m => m.Nombre == "Paracetamol")
            .SelectMany(m => m.MedicamentosVendidos!)
            .SumAsync(v => v.CantidadVendida);

        return totalVentasParacetamol;
    }

    //! Consulta Nro.8
    public async Task<double> ObtenerTotalDineroRecaudadoPorVentas()
    {
        var totalDineroRecaudado = await _Context.Ventas!
            .SelectMany(venta => venta.MedicamentosVendidos!)
            .SumAsync(detalle => Convert.ToDouble(detalle.ValorTotalVenta ?? "0"));

        return totalDineroRecaudado;
    }

    //! Consulta Nro.14
    public async Task<int> ObtenerTotalMedicamentosVendidosEnMarzo2023()
    {
        var fechaInicioMarzo2023 = new DateTime(2023, 3, 1);
        var fechaFinMarzo2023 = new DateTime(2023, 3, 31);

        var totalMedicamentosVendidos = await _Context.MedicamentosVendidos!
            .Where(mv => mv.Ventas!.FechaVenta >= fechaInicioMarzo2023 && mv.Ventas.FechaVenta <= fechaFinMarzo2023)
            .SumAsync(mv => mv.CantidadVendida);

        return totalMedicamentosVendidos;
    }

    //! Consulta Nro.15
    public async Task<Medicamento> ObtenerMedicamentoMenosVendidoEn2023()
    {
        var fechaInicio2023 = new DateTime(2023, 1, 1);
        var fechaFin2023 = new DateTime(2023, 12, 31);

        var medicamentoMenosVendido = await _Context.Medicamentos!
            .Where(m => m.MedicamentosVendidos!
                .Any(mv => mv.Ventas!.FechaVenta >= fechaInicio2023 && mv.Ventas.FechaVenta <= fechaFin2023))
            .OrderBy(m => m.MedicamentosVendidos!
                .Where(mv => mv.Ventas!.FechaVenta >= fechaInicio2023 && mv.Ventas.FechaVenta <= fechaFin2023)
                .Sum(mv => mv.CantidadVendida))
            .FirstOrDefaultAsync();

        return medicamentoMenosVendido!;
    }

    //! Consulta Nro.17
    public async Task<double> CalcularPromedioMedicamentosCompradosPorVenta()
    {
        var promedio = await _Context.Ventas!
            .Where(v => v.MedicamentosVendidos!.Any())
            .AverageAsync(v => v.MedicamentosVendidos!.Sum(mv => mv.CantidadVendida));

        return promedio;
    }

    //! Consulta Nro.18
    public async Task<Dictionary<string, int>> ObtenerCantidadVentasPorEmpleadoEn2023()
    {
        var ventasPorEmpleado = await _Context.Ventas!
            .Where(v => v.FechaVenta.Year == 2023)
            .GroupBy(v => v.Empleados!.Nombres + " " + v.Empleados.Apellidos) // Agrupamos por nombre completo del empleado
            .ToDictionaryAsync(
                group => group.Key, // Key es el nombre completo del empleado
                group => group.Count() // Contamos la cantidad de ventas para cada empleado
            );

        return ventasPorEmpleado;
    }

    public async Task<Venta> GetByClienteAsync(string cliente)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.Usuarios)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==cliente.ToLower()))!;
    }

    public async Task<Venta> GetByEmpleadoAsync(string empleado)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.Empleados)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==empleado.ToLower()))!;
    }

    public async Task<Venta> GetByMetodoDePagoAsync(string metodoDePago)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.MetodosDePagos)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==metodoDePago.ToLower()))!;
    }
}
