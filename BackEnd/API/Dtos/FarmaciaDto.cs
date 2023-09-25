namespace API.Dtos;
    public class FarmaciaDto{
        public int Id { get; set; }
        public string ? NombreFarmacia { get; set; }
        public string ? Propietario { get; set; }
        public DateTime? FechaInauguracion { get; set; }
        public int NumeroContacto { get; set; }
        public string ? URLSitioWeb { get; set; }
    }
