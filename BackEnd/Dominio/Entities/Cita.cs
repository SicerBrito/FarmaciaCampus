namespace Dominio.Entities;
    public class Cita : BaseEntity{
        
        public DateTime FechaCita { get; set; }
        public int ? EstadoCitaId { get; set;}
        public EstadoCita ? EstadoCitas { get; set; }
        public int ? MedicoId { get; set; }
        public Empleado ? Empleados { get; set; }
        public int UsuarioId { get; set; }
        public Usuario ? Usuarios { get; set; }

    }
