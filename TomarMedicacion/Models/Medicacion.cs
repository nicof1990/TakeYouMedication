using System.ComponentModel.DataAnnotations;

namespace TomarMedicacion.Models
{
    public class Medicacion
    {
        public int Id { get; set; }
        [MaxLength(125)]
        public string? Nombre { get; set; }
        [MaxLength(25)]
        public string? Dosis { get; set; }
    }
}
