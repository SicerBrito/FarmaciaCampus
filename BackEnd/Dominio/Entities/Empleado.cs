namespace Dominio.Entities;

     public class Empleado : BaseEntity{
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }

        public int CargoId { get; set; } 
        public Cargo ? Cargos { get; set; }

        public DateTime FechaContratacion { get; set; }
     }

