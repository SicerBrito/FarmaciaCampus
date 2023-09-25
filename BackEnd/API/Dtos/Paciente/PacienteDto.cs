namespace API.Dtos;
    public class PacienteDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public int NroContacto { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
