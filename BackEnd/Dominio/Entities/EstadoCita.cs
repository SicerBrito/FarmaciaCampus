

namespace Dominio.Entities;
    public class EstadoCita : BaseEntity{
        
        public string ? Nombre { get; set; }
        public ICollection<Cita> ? Citas { get; set; }

}
