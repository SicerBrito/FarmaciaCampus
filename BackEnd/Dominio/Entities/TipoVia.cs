namespace Dominio.Entities;
    public class TipoVia : BaseEntity{

        public string ? Nombre { get; set; }
        public string ? Abreviatura { get; set; }

        public ICollection<Direccion> ? Direcciones { get; set; }
    
    }
