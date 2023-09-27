namespace Dominio.Entities;

   public class Compra : BaseEntity{

      public DateTime FechaCompra { get; set; }
      public int ProveedorId { get; set; }
      public Proveedor ? Proveedores { get; set; }
      public int MetodoDePagoId { get; set; }
      public MetodoDePago ? MetodosDePagos { get; set; }
      public string ? NumeroFactura { get; set; }


      public ICollection<Inventario> ? Inventarios { get; set; }
      public ICollection<MedicamentosComprados> ? MedicamentosComprados { get; set; }

   }