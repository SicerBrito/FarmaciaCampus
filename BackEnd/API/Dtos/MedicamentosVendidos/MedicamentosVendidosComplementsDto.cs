using API.Dtos.Medicamento;

namespace API.Dtos.MedicamentosVendidos;
    public class MedicamentosVendidosComplementsDto{
        public int Id { get; set; }
        public int CantidadVendida { get; set; }
        public int ValorTotalVenta { get; set; }
        public int VentaId { get; set; }
        public List<VentaDto> ? Venta { get; set; }
        public int MedicamentoId { get; set; }
        public List<MedicamentoDto> ? Medicamento { get; set; }
    }
