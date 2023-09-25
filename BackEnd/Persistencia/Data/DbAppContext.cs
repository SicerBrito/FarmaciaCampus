using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
    public class DbAppContext : DbContext{
        public DbAppContext(DbContextOptions<DbAppContext> options) : base (options){

        }

        public DbSet<Usuario> ? Usuarios { get; set; } = null!;
        public DbSet<Rol> ? Roles { get; set; } = null!;
        public DbSet<UsuarioRol> ? UsuarioRoles { get; set; } = null!;
        public DbSet<CargoEmpleado> ? Cargos { get; set; } = null!;
        public DbSet<CategoriaMedicamento> ? Categorias { get; set; } = null!;
        public DbSet<Cita> ? Citas { get; set; } = null!;
        public DbSet<Ciudad> ? Ciudades { get; set; } = null!;
        public DbSet<Compra> ? Compras { get; set; } = null!;
        public DbSet<Departamento> ? Departamentos { get; set; } = null!;
        public DbSet<Direccion> ? Direcciones { get; set; } = null!;
        public DbSet<Empleado> ? Empleados { get; set; } = null!;
        public DbSet<EstadoCita> ? EstadoCitas { get; set; } = null!;
        public DbSet<Farmacia> ? Farmacias { get; set; } = null!;
        public DbSet<FormulaMedica> ? FormulasMedicas { get; set; } = null!;
        public DbSet<FormulaMedicamentos> ? FormulaMedicamentos { get; set; } = null!;
        public DbSet<Genero> ? Generos { get; set; } = null!;
        public DbSet<HistorialMedico> ? Historiales { get; set; } = null!;
        public DbSet<Inventario> ? Inventarios { get; set; } = null!;
        public DbSet<Medicamento> ? Medicamentos { get; set; } = null!;
        public DbSet<MedicamentosComprados> ? MedicamentosComprados { get; set; } = null!;
        public DbSet<MedicamentosVendidos> ? MedicamentosVendidos { get; set; } = null!;
        public DbSet<MetodoDePago> ? MetodoDePagos { get; set; } = null!;
        public DbSet<Paciente> ? Pacientes { get; set; } = null!;
        public DbSet<Pais> ? Paises { get; set; } = null!;
        public DbSet<Presentacion> ? Presentaciones { get; set; } = null!;
        public DbSet<Proveedor> ? Proveedores { get; set; } = null!;
        public DbSet<TipoDireccion> ? TipoDirecciones { get; set; } = null!;
        public DbSet<TipoMedicamento> ? TipoMedicamentos { get; set; } = null!;
        public DbSet<TipoVia> ? TipoVias { get; set; } = null!;
        public DbSet<Venta> ? Ventas { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        
    }
