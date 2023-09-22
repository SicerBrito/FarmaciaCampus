namespace Dominio.Entities;

  public class Direccion : BaseEntity{

    public string ? NombreDireccion { get; set; }
    public int TipoDireccionId { get; set; }
    public TipoDireccion ? TipoDirecciones { get; set; }
    public int TipoViaId { get; set; }
    public TipoVia ? TipoVias { get; set; }
    public int NroDireccion { get; set; }
    public int CiudadId { get; set; }
    public Ciudad ? Ciudades { get; set; }
    public int CodigoPostal { get; set; }
    public int FarmaciaId { get; set; }
    public Farmacia ? Farmacias { get; set; }

  }