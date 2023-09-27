namespace API.Dtos.MedicamentosVendidos;
    public class MedicamentosVendidosComplementsDto{
        public int Id { get; set; }
        public int CantidadVendida { get; set; }
        public string ? ValorTotalVenta { get; set; }
        public int VentaId { get; set; }
        public int MedicamentoId { get; set; }
    }
