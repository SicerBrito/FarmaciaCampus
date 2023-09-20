namespace Dominio.Entities;

     public class Farmacia : BaseEntity{
        public string ? Nombre { get; set;}
        public string ? Propietario { get; set; }

        public int DireccionId { get; set; }
        public Direccion ? Direcciones { get; set; }

        public DateTime Inauguracion { get; set; }
     }