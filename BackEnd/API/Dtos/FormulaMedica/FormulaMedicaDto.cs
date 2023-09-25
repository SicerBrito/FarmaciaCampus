namespace API.Dtos;
    public class FormulaMedicaDto{
        public int Id { get; set; }
        public DateTime FechaPrescripcion { get; set; }
        public string ? Posologia { get; set; }
        public int DuracionTratamiento { get; set; }
        public string ? Indicaciones { get; set; }
    }
