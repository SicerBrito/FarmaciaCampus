using API.Dtos.Paciente;

namespace API.Dtos;
    public class GeneroDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<PacienteComplementsDto> ? Pacientes { get; set; }
    }
