using API.Dtos.Ciudad;

namespace API.Dtos;
    public class DepartamentoDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        
        public List<CiudadComplementsDto> ? Ciudades { get; set; }
    }
