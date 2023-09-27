using API.Dtos.Inventario;
using API.Dtos.Medicamento;

namespace API.Dtos;
    public class CompraDto{
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public DateTime FechaCompra { get; set; }

        public List<InventarioComplementsDto> ? Inventarios { get; set; }
        public List<MedicamentosCompradosComplementsDto> ? MedicamentosComprados { get; set; }
    }
