namespace Dominio.Entities;
   public class Proveedor : BaseEntity{

      public string ? Nombres { get; set; }
      public string ? Apellidos { get; set; }
      public int NumeroContacto { get; set; }
      public ICollection<Compra> ? Compras { get; set; }
      public ICollection<Medicamento> ? Medicamentos { get; set; }

   }