using API.Dtos.Direccion;
using API.Dtos.Inventario;

namespace API.Dtos;
    public class FarmaciaDto{
        public int Id { get; set; }
        public string ? NombreFarmacia { get; set; }
        public string ? Propietario { get; set; }
        public DateTime? FechaInauguracion { get; set; }
        public string ? NumeroContacto { get; set; }
        public string ? URLSitioWeb { get; set; }
        
        public List<EmpleadoDto> ? Empleados { get; set; }
        public List<DireccionComplementsDto> ? Direcciones { get; set; }
        public List<InventarioComplementsDto> ? Inventarios { get; set; }
    }
