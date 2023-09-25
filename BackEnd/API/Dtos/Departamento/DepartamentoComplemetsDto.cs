namespace API.Dtos.Departamento;
    public class DepartamentoComplemetsDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public int PaisId { get; set; }
        public List<PaisDto> ? Paises { get; set; }
    }
