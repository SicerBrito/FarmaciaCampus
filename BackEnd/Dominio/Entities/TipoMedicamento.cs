namespace Dominio.Entities;

   public class TipoMedicamento : BaseEntity{
   
      public string ? Nombre { get; set; }
      public ICollection<Medicamento>? Medicamentos { get; set; }
      
   }