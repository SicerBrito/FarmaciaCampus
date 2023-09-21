namespace Dominio.Entities;
   public class MetodoDePago : BaseEntity{

      public string ? Nombre { get; set; }
      public ICollection<Compra> ? Compras { get; set; }
      public ICollection<Venta> ? Ventas { get; set; }
   
   }