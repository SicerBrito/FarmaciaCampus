using API.Dtos.Medicamento;

namespace API.Dtos;
    public class PresentacionDto{
        public int Id { get; set; }
        public string ? Descripcion { get; set; }

        public List<MedicamentoComplementsDto> ? Medicamentos { get; set; }
    }
