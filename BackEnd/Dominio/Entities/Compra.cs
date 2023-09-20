namespace Dominio.Entities;

     public class Compra : BaseEntity{
        public DateTime FechaCompra { get; set; }

        public int ProveedorId { get; set; }
        public proveedor ? Proveedores { get; set; }

        public int MetodoDePagoId { get; set; }
        public MetodoDePago ? MetodosDePagos { get; set; }

        public int NumeroFactura { get; set; }
        
     }