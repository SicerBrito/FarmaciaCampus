using API.Dtos.FormulaMedicamento;
using API.Dtos.MedicamentosVendidos;

namespace API.Dtos.Medicamento;
    public class MedicamentoDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public DateTime ? FechaExpiracion { get; set; }
        public string ? ValorUnidad { get; set; }

        public List<FormulaMedicamentoComplementsDto> ? FormulaMedicamentos { get; set; }
        public List<MedicamentosCompradosComplementsDto> ? MedicamentosComprados { get; set; }
        public List<MedicamentosVendidosComplementsDto> ? MedicamentosVendidos { get; set; }
    }
