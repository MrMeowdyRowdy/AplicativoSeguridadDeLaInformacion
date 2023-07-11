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
        public string? Tolerancia { get; set; }
        [Required]
        public string? Control { get; set; }
        public int RiesgoResidual { get; set; }
        public string? NivRiesgo { get; set; }
    }
}
