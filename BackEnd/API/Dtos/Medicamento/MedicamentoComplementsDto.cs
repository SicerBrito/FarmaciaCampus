namespace API.Dtos.Medicamento;
    public class MedicamentoComplementsDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public DateTime ? FechaExpiracion { get; set; }
        public int ValorUnidad { get; set; }
        public int TipoId { get; set; }
        public List<TipoMedicamentoDto> ? TipoMedicamento { get; set; }
        public int CategoriaId { get; set; }
        public List<CategoriaMedicamentoDto> ? CategoriaMedicamento { get; set; }
        public int PresentacionId { get; set; }
        public List<PresentacionDto> ? Presentacion { get; set;}
        public int ProveedorId { get; set; }
        public List<ProveedorDto> ? Proveedor { get; set; }
    }
