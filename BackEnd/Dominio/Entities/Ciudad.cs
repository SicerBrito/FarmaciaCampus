namespace Dominio.Entities;
    public class Ciudad : BaseEntity{
        
        public string ? Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento ? Departamentos { get; set; }

        public ICollection<Direccion> ? Direcciones { get; set; }
    
    }
