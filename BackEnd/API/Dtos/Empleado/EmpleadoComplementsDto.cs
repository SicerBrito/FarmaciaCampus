namespace API.Dtos.Empleado;
    public class EmpleadoComplementsDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Sueldo { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int FarmaciaId { get; set; }
        public int CargoId { get; set; }
    }
