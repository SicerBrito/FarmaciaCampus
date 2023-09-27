using API.Dtos.Compra;
using API.Dtos.Venta;

namespace API.Dtos;
    public class MetodoDePagoDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        
        public List<CompraComplementsDto> ? Compras { get; set; }
        public List<VentaComplementsDto> ? Ventas { get; set; }
    }
