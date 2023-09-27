using API.Dtos.Medicamento;

namespace API.Dtos;
    public class CategoriaMedicamentoDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<MedicamentoComplementsDto> ? Medicamentos { get; set; }
    }
