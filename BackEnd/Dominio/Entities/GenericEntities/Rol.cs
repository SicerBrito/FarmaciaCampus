namespace Dominio.Entities;
    public class Rol : BaseEntity{
        
        public string ? Nombre { get; set; }

        public int DireccionId { get; set; }
        public Direccion? Direcciones { get; set; }

        
        public ICollection<Usuario> ? Usuarios { get; set; } = new HashSet<Usuario>();
        public ICollection<UsuarioRol> ? UsuarioRoles { get; set; }
        
}
