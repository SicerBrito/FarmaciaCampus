namespace API.Dtos.Medicamento;
    public class MedicamentoDto{
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public DateTime ? FechaExpiracion { get; set; }
        public int ValorUnidad { get; set; }
    }
