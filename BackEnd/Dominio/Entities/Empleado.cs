namespace Dominio.Entities;

public class Empleado : BaseEntity{

    public int FarmaciaId { get; set; }
    public Farmacia ? Farmacias { get; set; }
    public string ? Nombres { get; set; }
    public string ? Apellidos { get; set; }
    public int CargoId { get; set; }
    public CargoEmpleado ? Cargos { get; set; }
    public string ? Sueldo { get; set; }
    public DateTime FechaContratacion { get; set; }

    
    public ICollection<Cita> ? Citas { get; set; }
    public ICollection<HistorialMedico> ? HistorialesMedicos { get; set; }
    public ICollection<FormulaMedica> ? FormulasMedicas { get; set; }
    public ICollection<Venta> ? Ventas { get; set; }

}

