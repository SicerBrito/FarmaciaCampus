using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IDireccion : IGenericRepository<Direccion>{
        Task<Direccion> GetByTipoDireccionAsync (string tipoDireccion);
        Task<Direccion> GetByTipoViasAsync (string tipoVias);
        Task<Direccion> GetByTipoCiudadesAsync (string ciudades);
        Task<Direccion> GetByFarmaciasAsync (string farmacias);
    }
