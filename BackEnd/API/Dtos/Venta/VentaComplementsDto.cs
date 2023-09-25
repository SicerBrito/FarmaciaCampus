namespace API.Dtos.Venta;
    public class VentaComplementsDto{
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public List<UsuarioDto> ? Cliente { get; set; }
        public int VentaEmpleadoId { get; set; }
        public List<EmpleadoDto> ? Empleado { get; set; }
        public int MetodoDePagoId { get; set; }
        public List<MetodoDePagoDto> ? MetodoDePago { get; set; }
    }
