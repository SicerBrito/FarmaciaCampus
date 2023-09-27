namespace API.Dtos.Medicamento;
    public class MedicamentosCompradosComplementsDto{
        public int Id { get; set; }
        public int CantidadCompra { get; set; }
        public string ? ValorTotalCompra { get; set; }
        public int CompraId { get; set; }
        public int MedicamentoId { get; set; }
    }
