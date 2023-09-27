using API.Dtos.Cita;
using API.Dtos.FormulaMedica;
using API.Dtos.HistorialMedico;
using API.Dtos.Venta;

namespace API.Dtos;
    public class EmpleadoDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Sueldo { get; set; }
        public DateTime FechaContratacion { get; set; } 

        public List<CitaComplementsDto> ? Citas { get; set; }
        public List<HistorialMedicoComplementsDto> ? HistorialesMedicos { get; set; }
        public List<FormulaMedicaComplementsDto> ? FormulasMedicas { get; set; }
        public List<VentaComplementsDto> ? Ventas { get; set; }
    }
