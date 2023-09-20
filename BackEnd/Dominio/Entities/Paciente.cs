namespace Dominio.Entities;

     public class Paciente : BaseEntity{
        public string ? Nombre { get; set; }
        public string ? Apellidos { get; set; }
        public int NumeroContacto { get; set; }
        public DataTime FechaNacimiento { get; set; }
        
        public int GeneroId { get; set; } 
        public Genero ? Generos { get; set; }

        public int DireccionId { get; set; }
        public Direccion ? Direcciones { get; set; }

        public int HistorialMedicoId { get; set; }
        public HistorialMedico ? HistorialesMedicos { get; set; }
     }