using System.ComponentModel.DataAnnotations;

namespace AplicativoSeguridad.Models
{
    public class Amenaza
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Tipo { get; set; }
        [Required]
        public string? Origen { get; set; }
        [Required]
        public string? Codigo { get; set; }
        public bool Hardware { get; set; }
        public bool Software { get; set; }
        public bool Redes { get; set; }
        public bool TH { get; set; }
    }
}
