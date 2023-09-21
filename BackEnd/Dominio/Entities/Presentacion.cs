namespace Dominio.Entities;
    public class Presentacion : BaseEntity{

        public string ? Descripcion { get; set; }
        public ICollection<Medicamento> ? Medicamentos { get; set; }

    }
