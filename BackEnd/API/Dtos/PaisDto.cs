using API.Dtos.Departamento;

namespace API.Dtos;
    public class PaisDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<DepartamentoComplemetsDto> ? Departamentos { get; set; }
    }
