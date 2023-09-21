namespace Dominio.Entities;
   public class Medicamento : BaseEntity{

      public string ? Nombre { get; set; }
      public int TipoId { get; set; }
      public TipoMedicamento ? Tipos { get; set; }
      public int CategoriaId { get; set; }
      public CategoriaMedicamento ? Categorias { get; set; }
      public int PresentacionId { get; set; }
      public Presentacion? Presentaciones { get; set; }
      public DateTime FechaExpiracion { get; set; }
      public int ValorUnidad { get; set; }
      public int ProveedorId  { get; set; }
      public Proveedor ? Proveedores { get; set; }
      
   
      public ICollection<MedicamentosComprados> ? MedicamentosComprados { get; set; }
      public ICollection<MedicamentosVendidos> ? MedicamentosVendidos { get; set; }
      public ICollection<FormulaMedicamentos> ? FormulaMedicamentos { get; set; }

   }