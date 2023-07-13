using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AplicativoSeguridad.Models
{
    public class RiesgoResidual
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Activo { get; set; }
        [Required]
        public string? Vulnerabilidad { get; set; }
        [Required]
        public string? Responsable { get; set; }
        [Required]
        public string? Tolerancia { get; set; }
        [Required]
        public string? NuevoControl { get; set; }
        public int RiesgoRes { get; set; }
        public string? NuevoNivRiesgo { get; set; }
    }
}
