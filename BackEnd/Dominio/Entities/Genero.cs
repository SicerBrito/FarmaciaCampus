namespace Dominio.Entities;
   public class Genero : BaseEntity{
      
      public string ? Nombre { get; set; }
      public ICollection<Paciente> ? Pacientes { get; set; }
     
   }