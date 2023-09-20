namespace Dominio.Entities;

     public class Medicamento : BaseEntity{
        public string ? Nombre { get; set; }

        public int TipoId { get; set: }
        public Tipo ? Tipos { get; set; }

        public int CategoriaId { get; set; }
        public Categoria ? Categorias { get; set; }

        public DateTime FechaExpiracion { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnidad { get; set; }
        public int ValorTotal { get; set; }
     }