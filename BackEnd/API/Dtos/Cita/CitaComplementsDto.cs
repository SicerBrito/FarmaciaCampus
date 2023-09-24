namespace API.Dtos.Cita;
    public class CitaComplementsDto{
        
        public int Id { get; set; }
        public DateTime FechaCita { get; set; }
        public int EstadoCitaId { get; set; }
        public List<EstadoCitaDto> ? EstadoCitas { get; set; }
        public int MedicoId { get; set; }
        public List<EmpleadoDto> ? Empleados { get; set; }
        public int UsuarioId { get; set; }
        public List<UsuarioDto> ? Usuarios { get; set; }

    }
