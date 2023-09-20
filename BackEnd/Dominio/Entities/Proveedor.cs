namespace Dominio.Entities;

     public class Proveedor : BaseEntity{
        public string ? Nombre { get; set; }
        public string ? Apellidos { get; set; }
        public int  NumeroContacto { get; set; }

        public int DireccionId { get; set; }
        public Direccion ? Direcciones { get; set; } 
     }