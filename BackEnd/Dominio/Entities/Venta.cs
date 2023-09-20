namespace Dominio.Entities;

     public class Venta : BaseEntity{
        public int VentaEmpleadoId { get; set; }
        public VentaEmpleado ? VentasEmpleados { get; set; }

        public DateTime FechaVenta { get; set; }

        public int ClienteId { get; set; }
        public Cliente ? Clientes { get; set; }

        public int MedicamentoId { get; set; }
        public Medicamento ? Medicamentos { get; set; }

        public int ValorTotalVenta { get; set; }

        public int MetodoDePagoId { get; set; }
        public MetodoDePago ? MetodosDePagos { get; set; }

        public int NumeroFactura { get; set; }
     }