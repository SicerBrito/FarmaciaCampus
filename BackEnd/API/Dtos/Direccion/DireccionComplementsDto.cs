namespace API.Dtos.Direccion;
    public class DireccionComplementsDto{
        public int Id { get; set; }
        public string ? NombreDireccion { get; set; }
        public int NroDireccion { get; set; }
        public int CodigoPostal { get; set; }
        public int TipoDireccionId { get; set; }
        public List<TipoDireccionDto> ? TipoDireccion { get; set; }
        public int TipoViaId { get; set; }
        public List<TipoViaDto> ? TipoVia { get; set; }
        public int CiudadId { get; set; }
        public List<CiudadDto> ? Ciudad { get; set; }
        public int FarmaciaId { get; set; }
        public List<FarmaciaDto> ? Farmacia { get; set; }
    }
