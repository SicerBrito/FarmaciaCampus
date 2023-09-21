namespace Dominio.Entities;
    public class MedicamentosVendidos : BaseEntity{

        public int VentaId { get; set; }
        public Venta ? Ventas { get; set; }
        public int MedicamentoId { get; set; }
        public Medicamento ? Medicamentos { get; set; }
        public int CantidadVendida { get; set; }
        public int ValorTotalVenta { get; set; }

    }
