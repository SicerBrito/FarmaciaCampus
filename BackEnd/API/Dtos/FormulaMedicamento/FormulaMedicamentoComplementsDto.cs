using API.Dtos.Medicamento;

namespace API.Dtos.FormulaMedicamento;
    public class FormulaMedicamentoComplementsDto{
        public int Id { get; set; }
        public int FomulaMedicaId { get; set; }
        public List<FormulaMedicaDto> ? FormulaMedica { get; set; }
        public int MedicamentoId { get; set; }
        public List<MedicamentoDto> ? Medicamento { get; set; }
    }
