namespace API.Dtos.Medicamento;
    public class MedicamentosCompradosComplementsDto{
        public int Id { get; set; }
        public string ? CantidadCompra { get; set; }
        public string ? ValorTotalCompra { get; set; }
        public int CompraId { get; set; }
        public List<CompraDto> ? Compra { get; set; }
        public int MedicamentoId { get; set; }
        public List<MedicamentoDto> ? Medicamento { get; set; }
    }
