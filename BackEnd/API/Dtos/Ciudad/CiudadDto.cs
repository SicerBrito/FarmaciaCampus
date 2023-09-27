using API.Dtos.Direccion;

namespace API.Dtos;
    public class CiudadDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<DireccionComplementsDto> ? Direcciones { get; set; }
    }
