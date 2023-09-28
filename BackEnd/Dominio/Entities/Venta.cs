namespace Dominio.Entities;
  public class Venta : BaseEntity{

    public DateTime FechaVenta { get; set; }
    public int ClienteId { get; set; }
    public Usuario ? Usuarios { get; set; }
    public int VentaEmpleadoId { get; set; }
    public Empleado ? Empleados { get; set; }
    public int MetodoDePagoId { get; set; }
    public MetodoDePago ? MetodosDePagos { get; set; }
    public string ? NumeroFactura { get; set; }

    
    public ICollection<Inventario> ? Inventarios { get; set; }
    public ICollection<MedicamentosVendidos> ? MedicamentosVendidos { get; set; }
    
}