namespace API.Dtos.Cita;
    public class CitaComplementsDto{
        
        public int Id { get; set; }
        public DateTime FechaCita { get; set; }
        public int EstadoCitaId { get; set; }
        public int MedicoId { get; set; }
        public int UsuarioId { get; set; }

    }
