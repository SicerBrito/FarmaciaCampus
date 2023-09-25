namespace Dominio.Entities;
    public class FormulaMedicamentos : BaseEntity{
        
        public int FomulaMedicaId { get; set; }
        public FormulaMedica ? FormulasMedicas { get; set; }
        public int MedicamentoId { get; set; } 
        public Medicamento? Medicamentos { get; set; }    
    
    }
