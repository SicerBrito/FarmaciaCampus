namespace Dominio.Entities;
    public class MedicamentosComprados : BaseEntity{

        public int Compra { get; set; }
        public Compra ? Compras { get; set; }
        public int Medicamento { get; set; }
        public Medicamento ? Medicamentos { get; set; }
        public int CantidadCompra { get; set; }
        public int ValorTotalCompra { get; set; }
                
    }
