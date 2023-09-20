namespace Dominio.Entities;

     public class Persona : BaseEntity{
        public int UsuarioId { get; set; }
        public Usuario ? Usuarios { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado ? Empleados { get; set; }

        public int PacienteId { get; set; }
        public Paciente ? Pacientes { get; set; }
     }