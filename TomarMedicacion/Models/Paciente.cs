using System.ComponentModel.DataAnnotations;

namespace TomarMedicacion.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Nombre { get; set; }
        [MaxLength(15)]
        public string? Celular { get; set; }
        
    }
}
