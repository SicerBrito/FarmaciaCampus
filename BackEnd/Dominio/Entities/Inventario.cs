namespace Dominio.Entities;
   public class Inventario : BaseEntity{

      public int FarmaciaId { get; set; }
      public Farmacia ? Farmacias { get; set; }
      public int CompraId { get; set; }
      public Compra ? Compras { get; set; }
      public int VentaId { get; set; }
      public Venta ? Ventas { get; set; }
      // public int Stock { get; set; }
      
   }