namespace Dominio.Entities;
   public class TipoDireccion : BaseEntity{

      public string ? Nombre { get; set; }
      public ICollection<Direccion> ? Direcciones { get; set; }

   }