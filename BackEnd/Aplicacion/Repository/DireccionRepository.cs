using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    private readonly DbAppContext _Context;
    public DireccionRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Direccion> GetByFarmaciasAsync(string farmacias)
    {
        return (await _Context.Set<Direccion>()
                            .Include(u => u.Farmacias)
                            .FirstOrDefaultAsync(u => u.NombreDireccion!.ToLower()==farmacias.ToLower()))!;
    }

    public async Task<Direccion> GetByTipoCiudadesAsync(string ciudades)
    {
        return (await _Context.Set<Direccion>()
                            .Include(u => u.Ciudades)
                            .FirstOrDefaultAsync(u => u.NombreDireccion!.ToLower()==ciudades.ToLower()))!;
    }

    public async Task<Direccion> GetByTipoDireccionAsync(string tipoDireccion)
    {
        return (await _Context.Set<Direccion>()
                            .Include(u => u.TipoDirecciones)
                            .FirstOrDefaultAsync(u => u.NombreDireccion!.ToLower()==tipoDireccion.ToLower()))!;
    }

    public async Task<Direccion> GetByTipoViasAsync(string tipoVias)
    {
        return (await _Context.Set<Direccion>()
                            .Include(u => u.TipoVias)
                            .FirstOrDefaultAsync(u => u.NombreDireccion!.ToLower()==tipoVias.ToLower()))!;
    }
}
