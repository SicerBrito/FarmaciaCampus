namespace Dominio.Entities;
   public class Farmacia : BaseEntity{

      public string ? NombreFarmacia { get; set;}
      public string ? Propietario { get; set; }
      public DateTime FechaInauguracion { get; set; }
      public string ? NumeroContacto { get; set; }
      public string ? URLSitioWeb { get; set; }


      
      public ICollection<Inventario> ? Inventarios { get; set; }
      public ICollection<Direccion> ? Direcciones { get; set; }
      public ICollection<Empleado> ? Empleados { get; set; }

   }