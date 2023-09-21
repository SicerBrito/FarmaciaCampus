namespace Dominio.Entities;
   public class CategoriaMedicamento : BaseEntity{

      public string ? Nombre { get; set; }
      public ICollection<Medicamento> ? Medicamentos { get; set; }

   }