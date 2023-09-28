namespace API.Dtos.Medicamento;
    public class MedicamentoComplementsDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public DateTime ? FechaExpiracion { get; set; }
        public string ? ValorUnidad { get; set; }
        public int TipoId { get; set; }
        public int CategoriaId { get; set; }
        public int PresentacionId { get; set; }
        public int ProveedorId { get; set; }
        public int Stock { get; set; }
    }
