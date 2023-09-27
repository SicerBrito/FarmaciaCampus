using API.Dtos.Direccion;

namespace API.Dtos;
    public class TipoViaDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public string ? Abreviatura { get; set; }

        public List<DireccionComplementsDto> ? Direcciones { get; set; }
    }
