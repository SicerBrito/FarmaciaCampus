namespace API.Dtos.Paciente;
    public class PacienteComplementsDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public int NroContacto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public List<GeneroDto> ? Genero { get; set; }
    }
