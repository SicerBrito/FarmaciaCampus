using API.Dtos.Compra;
using API.Dtos.Medicamento;

namespace API.Dtos;
    public class ProveedorDto{
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? NroContacto { get; set; }
        
        public List<CompraComplementsDto> ? Compras { get; set; }
        public List<MedicamentoComplementsDto> ? Medicamentos { get; set; }
    }
