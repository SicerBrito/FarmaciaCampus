namespace Dominio.Entities;

     public class Direccion : BaseEntity{
        public string ? NNDireccion { get; set; }

        public int TipoId { get; set; }
        public Tipo ? Tipos { get; set; }

        public int TipoViaId { get; set; }
        public TipoVia ? TiposVias { get; set; }

        public int NumeroDireccion { get; set; }
        public string ? Ciudad { get; set; }
        public string ? Estado { get; set; }
        public int CodigoPostal { get; set; }
        public string ? Pais { get; set; }

        public int FarmaciaId { get; set; }
        public Farmacia ? Farmacias { get; set; }

     }