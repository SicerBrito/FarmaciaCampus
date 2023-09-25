using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbAppContext ? _Context;
        public UnitOfWork(DbAppContext context){
            _Context = context;
        }



        RolRepository ? _Rol;
        UsuarioRepository ? _Usuario;
        CargoEmpleadoRepository ? _CargoEmpleado;
        CategoriaMedicamentoRepository ? _CategoriaMedicamento;
        CitaRepository ? _Cita;
        CiudadRepository ? _Ciudad;
        CompraRepository ? _Compra;
        DepartamentoRepository ? _Departamento;
        DireccionRepository ? _Direccion;
        EmpleadoRepository ? _Empleado;
        EstadoCitaRepository ? _EstadoCita;
        FarmaciaRepository ? _Farmacia;
        FormulaMedicaRepository ? _FormulaMedica;
        FormulaMedicamentosRepository ? _FormulaMedicamentos;
        GeneroRepository ? _Genero;
        HistorialMedicoRepository ? _HistorialMedico;
        InventarioRepository ? _Inventario;
        MedicamentoRepository ? _Medicamento;
        MedicamentosCompradosRepository ? _MedicamentosComprados;
        MedicamentosVendidosRepository ? _MedicamentosVendidos;
        MetodoDePagoRepository ? _MetodoDePago;
        PacienteRepository ? _Paciente;
        PaisRepository ? _Pais;
        PresentacionRepository ? _Presentacion;
        ProveedorRepository ? _Proveedor;
        TipoDireccionRepository ? _TipoDireccion;
        TipoMedicamentoRepository ? _TipoMedicamento;
        TipoViaRepository ? _TipoVia;
        VentaRepository ? _Venta;



        
        public IRol ? Roles => _Rol ??= new RolRepository(_Context!);
        public IUsuario ? Usuarios => _Usuario ??= new UsuarioRepository(_Context!);
        public ICargoEmpleado ? CargoEmpleados => _CargoEmpleado ??= new CargoEmpleadoRepository(_Context!);
        public ICategoriaMedicamento ? CategoriaMedicamentos => _CategoriaMedicamento ??= new CategoriaMedicamentoRepository(_Context!);
        public ICita ? Citas => _Cita ??= new CitaRepository(_Context!);
        public ICiudad ? Ciudades => _Ciudad ??= new CiudadRepository(_Context!);
        public ICompra ? Compras => _Compra ??= new CompraRepository(_Context!);
        public IDepartamento ? Departamentos => _Departamento ??= new DepartamentoRepository(_Context!);
        public IDireccion ? Direcciones => _Direccion ??= new DireccionRepository(_Context!);
        public IEmpleado ? Empleados => _Empleado ??= new EmpleadoRepository(_Context!);
        public IEstadoCita ? EstadoCitas => _EstadoCita ??= new EstadoCitaRepository(_Context!);
        public IFarmacia ? Farmacias => _Farmacia ??= new FarmaciaRepository(_Context!);
        public IFormulaMedica ? FormulasMedicas => _FormulaMedica ??= new FormulaMedicaRepository(_Context!);
        public IFormulaMedicamentos? FormulaMedicamentos => _FormulaMedicamentos ??= new FormulaMedicamentosRepository(_Context!);
        public IGenero ? Generos => _Genero ??= new GeneroRepository(_Context!);
        public IHistorialMedico ? HistorialesMedicos => _HistorialMedico ??= new HistorialMedicoRepository(_Context!);
        public IInventario? Inventarios => _Inventario ??= new InventarioRepository(_Context!);
        public IMedicamento ? Medicamentos => _Medicamento ??= new MedicamentoRepository(_Context!);
        public IMedicamentosComprados ? MedicamentosComprados => _MedicamentosComprados ??= new MedicamentosCompradosRepository(_Context!);
        public IMedicamentosVendidos ? MedicamentosVendidos => _MedicamentosVendidos ??= new MedicamentosVendidosRepository(_Context!);
        public IMetodoDePago ? MetodosDePagos => _MetodoDePago ??= new MetodoDePagoRepository(_Context!);
        public IPaciente ? Pacientes => _Paciente ??= new PacienteRepository(_Context!);
        public IPais ? Paises => _Pais ??= new PaisRepository(_Context!);
        public IPresentacion ? Presentaciones => _Presentacion ??= new PresentacionRepository(_Context!);
        public IProveedor ? Proveedores => _Proveedor ??= new ProveedorRepository(_Context!);
        public ITipoDireccion ? TipoDirecciones => _TipoDireccion ??= new TipoDireccionRepository(_Context!);
        public ITipoMedicamento ? TipoMedicamentos => _TipoMedicamento ??= new TipoMedicamentoRepository(_Context!);
        public ITipoVia ? TipoVias => _TipoVia ??= new TipoViaRepository(_Context!);
        public IVenta ? Ventas => _Venta ??= new VentaRepository(_Context!);

    public void Dispose(){
            _Context!.Dispose();
            GC.SuppressFinalize(this); 
        }

        public Task<int> SaveAsync(){
            return _Context!.SaveChangesAsync();
        }
    }
