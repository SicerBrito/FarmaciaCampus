namespace Dominio.Entities;
    public class CargoEmpleado : BaseEntity{

        public string ? Nombre { get; set; }
        public ICollection<Empleado> ? Empleados { get; set; } 

    }