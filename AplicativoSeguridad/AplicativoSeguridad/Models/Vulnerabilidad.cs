using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AplicativoSeguridad.Models
{
    public class Vulnerabilidad
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Amenaza { get; set; }
        [Required]
        public string? Activo { get; set; }
        [Required]
        public string? Codigo { get; set; }
        [Required, Range(1, 3)]
        public int NivAmenaza { get; set; }
        [Required, Range(1, 3)]
        public int NivVulnerabilidad { get; set; }
        [Required]
        public string? ControlAplicado { get; set; }
        public int? ValorRiesgo { get; set; }
        public string? RiesgoInherente { get; set; }

    }
}
