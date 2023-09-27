using API.Dtos.Inventario;
using API.Dtos.MedicamentosVendidos;

namespace API.Dtos;
    public class VentaDto{
        public int Id { get; set; }
        public string ? NumeroFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        
        public List<InventarioComplementsDto> ? Inventarios { get; set; }
        public List<MedicamentosVendidosComplementsDto> ? MedicamentosVendidos { get; set; }
    }
