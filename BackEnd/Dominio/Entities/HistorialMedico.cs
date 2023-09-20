namespace Dominio.Entities;

     public class HistorialMedico : BaseEntity{
        public int PacienteId { get; set; }
        public Paciente ? Pacientes { get; set; }

        public int MedicoId { get; set; }
        public Medico ? Medicos { get; set; }

        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }
     }