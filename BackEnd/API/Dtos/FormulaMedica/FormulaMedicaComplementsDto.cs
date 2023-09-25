namespace API.Dtos.FormulaMedica;
    public class FormulaMedicaComplementsDto{
        public int Id { get; set; }
        public DateTime FechaPrescripcion { get; set; }
        public int PacienteId { get; set; }
        public List<PacienteDto> ? Paciente { get; set; }
        public int MedicoId { get; set; }
        public List<EmpleadoDto> ? Empleado { get; set; }
        public string ? Posologia { get; set; }
        public int DuracionTratamiento { get; set; }
        public string ? Indicaciones { get; set; }
    }
