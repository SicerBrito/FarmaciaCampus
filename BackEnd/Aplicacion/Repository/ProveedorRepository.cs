using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly DbAppContext _Context;
    public ProveedorRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _Context.Set<Proveedor>()
                                    .Include(u => u.Compras)
                                    .Include(u => u.Medicamentos)
                                    .ToListAsync();
    }
    
    //! Consulta Nro. 2
    public async Task<List<Proveedor>> ListarProveedoresConInformacionDeContacto()
    {
        return await _Context.Proveedores!
            .Include(p => p.Medicamentos)
            .Select(p => new Proveedor
            {
                Nombres = p.Nombres + " " + p.Apellidos,
                Apellidos = p.Apellidos,
                Compras = p.Compras,
                Medicamentos = p.Medicamentos!.Select(m => new Medicamento
                {
                    Nombre = m.Nombre,
                    ValorUnidad = m.ValorUnidad,
                    Stock = m.Stock
                }).ToList()
            })
            .ToListAsync();
    }

    //! Consulta Nro.13
    public async Task<List<Proveedor>> ObtenerProveedoresQueNoHanVendidoEnUltimoAnio()
    {
        var fechaHaceUnAnio = DateTime.Now.AddYears(-1);

        var proveedores = await _Context.Proveedores!
            .Where(proveedor => !proveedor.Compras!.Any(compra => compra.FechaCompra >= fechaHaceUnAnio))
            .ToListAsync();

        return proveedores;
    }

}
