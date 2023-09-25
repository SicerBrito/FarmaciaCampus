namespace API.Dtos;
    public class EmpleadoDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public int Sueldo { get; set; }
        public DateTime FechaContratacion { get; set; } 
    }
