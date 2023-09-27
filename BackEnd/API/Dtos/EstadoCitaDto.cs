using API.Dtos.Cita;

namespace API.Dtos;
    public class EstadoCitaDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<CitaComplementsDto> ? Citas { get; set; }
    }
