using System.Globalization;
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

    //! Consulta Nro.26
    public async Task<Dictionary<string, int>> ObtenerTotalMedicamentosVendidosPorMesEn2023()
    {
        var ventasEn2023 = await _Context.Ventas!
            .Where(v => v.FechaVenta.Year == 2023)
            .ToListAsync();

        var totalPorMes = new Dictionary<string, int>();

        foreach (var mes in Enumerable.Range(1, 12))
        {
            var mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            var totalVentasEnMes = ventasEn2023
                .Count(v => v.FechaVenta.Month == mes);
            totalPorMes.Add(mesNombre, totalVentasEnMes);
        }

        return totalPorMes;
    }

    //! Consulta Nro.27
    public async Task<List<Empleado>> ObtenerEmpleadosConMenosDe5VentasEn2023()
    {
        var empleadosConVentasEn2023 = await _Context.Ventas!
            .Where(v => v.FechaVenta.Year == 2023)
            .Select(v => v.Empleados)
            .Distinct()
            .ToListAsync();

        if (empleadosConVentasEn2023 != null)
        {
            var empleadosConMenosDe5Ventas = empleadosConVentasEn2023
                .Where(e => e != null && e.Ventas != null && e.Ventas.Count(v => v.FechaVenta.Year == 2023) < 5)
                .ToList();

            return empleadosConMenosDe5Ventas!;
        }
        else
        {
            // La secuencia es nula, maneja este caso según tus necesidades.
            return new List<Empleado>(); // O devuelve una lista vacía u otro valor predeterminado.
        }
    }

    //! Consulta Nro.36
    public async Task<int> ObtenerTotalMedicamentosVendidosPrimerTrimestre2023()
    {
        var fechaInicioTrimestre = new DateTime(2023, 1, 1);
        var fechaFinTrimestre = new DateTime(2023, 3, 31);

        var totalMedicamentosVendidos = await _Context.MedicamentosVendidos!
            .Where(mv => mv.Ventas!.FechaVenta >= fechaInicioTrimestre && mv.Ventas.FechaVenta <= fechaFinTrimestre)
            .SumAsync(mv => mv.CantidadVendida);

        return totalMedicamentosVendidos;
    }

    //! Consulta Nro.37
    public async Task<List<Empleado>> ObtenerEmpleadosSinVentasAbril2023()
    {
        var fechaInicioAbril2023 = new DateTime(2023, 4, 1);
        var fechaFinAbril2023 = new DateTime(2023, 4, 30);

        var empleadosConVentasAbril2023 = await _Context.Ventas!
            .Where(v => v.FechaVenta >= fechaInicioAbril2023 && v.FechaVenta <= fechaFinAbril2023)
            .Select(v => v.Empleados)
            .Distinct()
            .ToListAsync();

        var todosEmpleados = await _Context.Empleados!.ToListAsync();
        var empleadosSinVentasAbril2023 = todosEmpleados.Except(empleadosConVentasAbril2023).ToList();

        return empleadosSinVentasAbril2023!;
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
