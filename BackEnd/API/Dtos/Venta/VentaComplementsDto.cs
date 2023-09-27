namespace API.Dtos.Venta;
    public class VentaComplementsDto{
        public int Id { get; set; }
        public string ? NumeroFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public int VentaEmpleadoId { get; set; }
        public int MetodoDePagoId { get; set; }
    }
