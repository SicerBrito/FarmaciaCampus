namespace API.Dtos.Ciudad;
    public class CiudadComplementsDto
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public List<DepartamentoDto> ? Departamentos { get; set; }
    }
