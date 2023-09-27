namespace API.Dtos.HistorialMedico;
    public class HistorialMedicoComplementsDto{
        public int Id { get; set; }
        public string ? Diagnostico { get; set; }
        public string ? Tratamiento { get; set; }
        public string ? Observaciones { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
    }
