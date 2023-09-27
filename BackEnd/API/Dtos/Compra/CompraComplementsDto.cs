namespace API.Dtos.Compra;
    public class CompraComplementsDto{
        public int Id { get; set; }
        public string ? NumeroFactura { get; set; }
        public DateTime FechaCompra { get; set; }
        public int ProveedorId { get; set; }
        public int MetodoDePagoId { get; set; }
        
    }
