namespace API.Dtos.Inventario;
    public class InventarioComplementsDto{
        public int Id { get; set; }
        public int FarmaciaId { get; set; }
        public List<FarmaciaDto> ? Farmacia { get; set; }
        public int CompraId { get; set; }
        public List<CompraDto> ? Compra { get; set; }
        public int VentaId { get; set; }
        public List<VentaDto> ? Venta { get; set; }
    }
