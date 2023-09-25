namespace API.Dtos.Empleado;
    public class EmpleadoComplementsDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public int Sueldo { get; set; }
        public int FarmaciaId { get; set; }
        public DateTime FechaContratacion { get; set; }
        public List<FarmaciaDto> ? Farmacia { get; set; }
        public int CargoId { get; set; }
        public List<CargoEmpleadoDto> ? CargoEmpleado { get; set; }
    }
