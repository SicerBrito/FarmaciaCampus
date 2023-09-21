namespace Dominio.Entities;
   public class Paciente : BaseEntity{

      public string ? Nombres { get; set; }
      public string ? Apellidos { get; set; }
      public int NumeroContacto { get; set; }
      public DateTime FechaNacimiento { get; set; }
      public int GeneroId { get; set; } 
      public Genero ? Generos { get; set; }
      public ICollection<HistorialMedico> ? HistorialesMedicos { get; set; }
      public ICollection<FormulaMedica> ? FormulasMedicas { get; set; }
   
   }