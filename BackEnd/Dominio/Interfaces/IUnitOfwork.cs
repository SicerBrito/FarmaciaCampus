namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        
        IUsuario ? Usuarios { get; }
        IRol ? Roles { get; }
        ICargoEmpleado ? CargoEmpleados { get; }
        ICategoriaMedicamento ? CategoriaMedicamentos { get; }
        ICita ? Citas { get; }
        ICiudad ? Ciudades { get; }
        ICompra ? Compras { get; }
        IDepartamento ? Departamentos { get; }
        IDireccion ? Direcciones { get; }
        IEmpleado ? Empleados { get; }
        IEstadoCita ? EstadoCitas { get; }
        IFarmacia ? Farmacias { get; }
        IFormulaMedica ? FormulasMedicas { get; }
        IGenero ? Generos { get; }
        IHistorialMedico ? HistorialesMedicos { get; }
        IMedicamento ? Medicamentos { get; }
        IMedicamentosComprados ? MedicamentosComprados { get; }
        IMedicamentosVendidos ? MedicamentosVendidos { get; }
        IMetodoDePago ? MetodosDePagos { get; }
        IPaciente ? Pacientes { get; }
        IPais ? Paises { get; }
        IPresentacion ? Presentaciones { get; }
        IProveedor ? Proveedores { get; }
        ITipoDireccion ? TipoDirecciones { get; }
        ITipoMedicamento ? TipoMedicamentos { get; }
        ITipoVia ? TipoVias { get; }
        IVenta ? Ventas { get; }
        Task<int> SaveAsync();
        
    }
