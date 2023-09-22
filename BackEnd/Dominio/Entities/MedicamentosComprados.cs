namespace Dominio.Entities;
    public class MedicamentosComprados : BaseEntity{

        public int CompraId { get; set; }
        public Compra ? Compras { get; set; }
        public int MedicamentoId { get; set; }
        public Medicamento ? Medicamentos { get; set; }
        public int CantidadCompra { get; set; }
        public int ValorTotalCompra { get; set; }
                
    }
