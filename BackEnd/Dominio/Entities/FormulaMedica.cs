namespace Dominio.Entities;
    public class FormulaMedica : BaseEntity{

        public int PacienteId { get; set; }
        public Paciente ? Pacientes { get; set; }
        public DateTime FechaPrescripcion { get; set; }
        public int MedicoId { get; set; } // aqui es el rol de medico
        public Empleado ? Empleados { get; set; }
        public string ? Posologia { get; set; } // Las instrucciones de dosificación para cada medicamento, incluyendo la cantidad y la frecuencia.
        public int DuracionTratamiento { get; set; }
        public string ? Indicaciones { get; set; }
        

        public ICollection<FormulaMedicamentos> ? FormulaMedicamentos { get; set; }

    }
